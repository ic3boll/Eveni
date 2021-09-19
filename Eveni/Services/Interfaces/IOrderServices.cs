using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Order;
using Web.ViewModels.Orders;

namespace Web.Services.Interfaces
{
   public interface IOrderServices
    {
        public Task CreateAsync(OrderDetailInputModel odim, string items, string CookieID);
        public Task<IReadOnlyCollection<OrderViewModel>> GetUserOrdersAsync(string UserId);
    }
}
