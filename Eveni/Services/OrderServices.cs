using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
using Web.Models.Order;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<OrderSecurity> _orderSecurityRepository;
        public readonly IMapper _mapper;
        private readonly ICookieHelper _cookieHelper;
        public OrderServices(IAsyncRepository<Order> orderRepository,
            IMapper mapper,
            IAsyncRepository<OrderSecurity> orderSecurityRepository,
            ICookieHelper cookieHelper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
            this._orderSecurityRepository = orderSecurityRepository;
            this._cookieHelper = cookieHelper;
        }

        public async Task CreateAsync(OrderDetailInputModel odim, string items, string UserId)
        {
            var ipToAdd = new OrderSecurity();
            var ip = await _orderSecurityRepository.GetAllAsync();

            Order_Detail order_Detail = _mapper.Map<Order_Detail>(odim);
            order_Detail.CookieId = UserId;
            string cookieRequest = "CookieCart";

            Order order = new Order
            {
                Order_Detail = order_Detail,
                CookieID = UserId,
                Items = items
            };
            foreach (var item in ip)
            {
                if (item.Ip == UserId)
                {
                    ipToAdd = _mapper.Map<OrderSecurity>(item);
                    if (ipToAdd.TimePlaced.Minute != DateTime.Now.Minute)
                    {
                        ipToAdd.TimePlaced = DateTime.Now;
                        await this._orderSecurityRepository.UpdateAsync(ipToAdd);
                        await this._orderRepository.AddAsync(order);
                        _cookieHelper.Remove(cookieRequest);
                    }
                }
            }
            if(ipToAdd.Ip == null)
            {
                ipToAdd.Ip = UserId;
                ipToAdd.TimePlaced = DateTime.Now;
                await this._orderSecurityRepository.AddAsync(ipToAdd);
                await this._orderRepository.AddAsync(order);
                _cookieHelper.Remove(cookieRequest);
            }
        }
    }
}
