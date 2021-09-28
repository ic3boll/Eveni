using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
using Web.Models.Order;
using Web.Services.Interfaces;
using Web.ViewModels.Item;
using Web.ViewModels.Orders;

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
            if (ipToAdd.Ip == null)
            {
                ipToAdd.Ip = UserId;
                ipToAdd.TimePlaced = DateTime.Now;
                await this._orderSecurityRepository.AddAsync(ipToAdd);
                await this._orderRepository.AddAsync(order);
                _cookieHelper.Remove(cookieRequest);
            }
        }

        public async Task<IReadOnlyCollection<OrderViewModel>> GetUserOrdersAsync(string UserId)
        {
            var orders = await _orderRepository.GetAllAsync();
            var userOrders = orders.Where(u => u.CookieID == UserId).ToList().AsReadOnly();
            var mappedUserOrders = _mapper.Map<IReadOnlyCollection<OrderViewModel>>(userOrders);
            return mappedUserOrders;
        }

        public List< UserOrderViewModel> DeserializeOrderItems(List<OrderViewModel> UserOrdersAsList)
        {
            UserOrderViewModel deserializedOrders = new UserOrderViewModel();
            List<UserOrderViewModel> deserializedOrdersAsList = new List<UserOrderViewModel>();

            foreach (var item in UserOrdersAsList)
            {
                deserializedOrders.items = JsonConvert.DeserializeObject<List<ItemViewModel>>(item.Items);
                deserializedOrdersAsList.Add(deserializedOrders);
            }

            return deserializedOrdersAsList;
        }
    }
}
