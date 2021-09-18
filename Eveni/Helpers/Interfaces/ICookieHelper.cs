using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helpers.Interfaces
{
<<<<<<< HEAD
   public interface ICookieHelper
=======
    interface ICookieHelper
>>>>>>> 69be7186e6db8becd689a22ccfabdd39dae266e9
    {
        public void Set(Product productId, CookieOptions options, string cookieRequest);

        public void Set(int id, Product productId, CookieOptions options, string cookieRequest);

<<<<<<< HEAD
        public void Remove(string cookieRequest);

=======
>>>>>>> 69be7186e6db8becd689a22ccfabdd39dae266e9
    }
}
