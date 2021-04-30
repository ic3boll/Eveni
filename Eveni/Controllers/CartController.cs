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

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductServices _productServices;
        public CartController(IProductServices productServices)
        {
            this._productServices = productServices;
        }
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }
        
      
       
        [Route("Buy")]
        public async Task<IActionResult> Buy(int id)
        {
            CartProductViewModel productModel = new CartProductViewModel();
            var productId = await _productServices.GetProductId(id);
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product=productId, Quantity = 1 });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productId, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Home","Home");
        }

      // [Route("remove/{id}")]
      // public IActionResult Remove(string id)
      // {
      //     List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
      //     int index = isExist(id);
      //     cart.RemoveAt(index);
      //     SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
      //     return RedirectToAction("Index");
      // }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
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
