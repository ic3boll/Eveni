using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;

namespace Web.Helpers
{
    public class CookieHelper : ICookieHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public void Set(Product productId, CookieOptions options, string cookieRequest)
        {
            List<Item> cart = new List<Item>
            {
                new Item { Product = productId, Quantity = 1 }
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieRequest, JsonConvert.SerializeObject(cart), options);
        }

        public void Set(int id, Product productId, CookieOptions options, string cookieRequest)
        {

            var cart =  JsonConvert.DeserializeObject<List<Item>>(_httpContextAccessor.HttpContext.Request.Cookies[cookieRequest]);
            int index = isExist(id);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            else
            {
                cart.Add(new Item { Product = productId, Quantity = 1 });
            }
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieRequest, JsonConvert.SerializeObject(cart), options);
        }

        [Obsolete]
        public void Remove(string cookieRequest)
        {
            var co = new CookieOptions()
            {
                Expires = DateTime.Now.AddSeconds(1)
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieRequest,"", co);
        }
        private int isExist(int id)
        {
            var cart = JsonConvert.DeserializeObject<List<Item>>(_httpContextAccessor.HttpContext.Request.Cookies["CookieCart"]);
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}