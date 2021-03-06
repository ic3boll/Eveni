using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Web.Helpers;
using Web.ViewModels.Products;
using Web.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using Web.Helpers.Interfaces;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICookieHelper _cookieHelper;
        public CartController(IProductServices productServices,
            ICookieHelper cookieHelper)
        {
            this._cookieHelper = cookieHelper;
            this._productServices = productServices;
        }
        [Route("Your_Cart")]
        public IActionResult Index()
        {
          if(Request.Cookies["CookieCart"]==null)
            {

                return RedirectToAction("Home", "Home");
            }
            var CookiCart = JsonConvert.DeserializeObject<List<Item>>(Request.Cookies["CookieCart"]);
            ViewBag.cart = CookiCart;
            ViewBag.total = CookiCart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }
        
      
       
        [Route("Buy")]
        [Obsolete]
        public async Task<IActionResult> Buy(int id)
        {

            var cookieRequest = "CookieCart";
            var productId = await _productServices.GetIdAsync(id);

            var cookieOptions = new CookieOptions()
            {
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                IsEssential = true,
                HttpOnly = false,
                Secure = false,
            };
            if (Request.Cookies[cookieRequest] == null)
            {
                //SET if null:
                _cookieHelper.Set(productId, cookieOptions, cookieRequest);

                return RedirectToAction("Home", "Home");
            }
                //SET:
                _cookieHelper.Set(id, productId, cookieOptions, cookieRequest);
            
            return RedirectToAction("Home","Home");
        }

       [Route("remove/{id}")]
       public IActionResult Remove(int id)
       {
           List<Item> cart = JsonConvert.DeserializeObject<List<Item>>(Request.Cookies["CookieCart"]);
            int index = isExist(id);
           cart.RemoveAt(index);
           Response.Cookies.Append("CookieCart", JsonConvert.SerializeObject(cart));
           return RedirectToAction("Index");
       }

        private int isExist(int id)
        {
            var cart = JsonConvert.DeserializeObject<List<Item>>(Request.Cookies["CookieCart"]);
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
