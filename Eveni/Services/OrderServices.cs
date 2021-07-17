using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        public OrderServices(IAsyncRepository<Order> orderRepository,IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public async Task CreateAsync(OrderDetailInputModel odim, string items, string UserId)
        {
          
            Order_Detail order_Detail  = _mapper.Map<Order_Detail>(odim);
            order_Detail.CookieId = UserId;

            Order order = new Order { 
             Order_Detail = order_Detail,
             CookieID=UserId,
             Items=items
            };

            await _orderRepository.AddAsync(order);
            
        }

    }
}
