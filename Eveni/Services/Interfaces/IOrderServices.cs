using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Order;

namespace Web.Services.Interfaces
{
   public interface IOrderServices
    {
        public Task CreateAsync(OrderDetailInputModel odim, string items, string CookieID);
    }
}
