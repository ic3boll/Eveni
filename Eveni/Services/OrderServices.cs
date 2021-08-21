using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<OrderSecurity> _orderSecurityRepository;
        private readonly IMapper _mapper;
        public OrderServices(IAsyncRepository<Order> orderRepository,
            IMapper mapper,
            IAsyncRepository<OrderSecurity> orderSecurityRepository)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
            this._orderSecurityRepository = orderSecurityRepository;
        }

        public async Task CreateAsync(OrderDetailInputModel odim, string items, string UserId)
        {
            int count = 0;
            Order_Detail order_Detail = _mapper.Map<Order_Detail>(odim);
            order_Detail.CookieId = UserId;

            Order order = new Order
            {
                Order_Detail = order_Detail,
                CookieID = UserId,
                Items = items
            };
            // RAW !
            var ip = await _orderSecurityRepository.GetAllAsync();

            var ipToAdd = new OrderSecurity();
            ipToAdd.Ip = UserId;
            ipToAdd.TimePlaced = DateTime.Now;

            foreach (var item in ip)
            {
                if (item.Ip != UserId)
                {
                    count++;
                }

            }
            //Check for existing if not add
            if (count == ip.Count)
            {
                await _orderSecurityRepository.AddAsync(ipToAdd);
            } 

            //if existed check for hour placement then add
           
            else if (ipToAdd.TimePlaced.Hour < DateTime.Now.Hour)
            {
                await _orderSecurityRepository.AddAsync(ipToAdd);
            }
            await _orderRepository.AddAsync(order);


           // CheckForExistingIp(UserId, ip, ipToAdd, order);

           

        }


       
    }
}
