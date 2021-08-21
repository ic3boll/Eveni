<<<<<<< .mine
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Interfaces
{
   public interface IOrderSecurityServices
    {
        public Task CreateAsync(OrderSecurity os);

        public Task<IReadOnlyCollection<OrderSecurity>> GetAllAsync();
    
    }
}
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Interfaces
{
   public interface IOrderSecurityServices
    {

    }
}




>>>>>>> .theirs
