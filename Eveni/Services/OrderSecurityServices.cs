using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class OrderSecurityServices : IOrderSecurityServices
    {
        private readonly IAsyncRepository<OrderSecurity> _orderSecurityRepository;
        public OrderSecurityServices(IAsyncRepository<OrderSecurity>orderSecurityRepository)
        {
            this._orderSecurityRepository = orderSecurityRepository;
        }

        public async Task CreateAsync(OrderSecurity os)
        {
            await _orderSecurityRepository.AddAsync(os);
        }

        public async Task<IReadOnlyCollection<OrderSecurity>> GetAllAsync()
        {
            var products = await this._orderSecurityRepository.GetAllAsync();
            return products;
        }

    }
}
