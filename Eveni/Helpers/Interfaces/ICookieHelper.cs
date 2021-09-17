using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helpers.Interfaces
{
    interface ICookieHelper
    {
        public void Set(Product productId, CookieOptions options, string cookieRequest);

        public void Set(int id, Product productId, CookieOptions options, string cookieRequest);

    }
}
