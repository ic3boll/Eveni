using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Services.Interfaces;
using Web.ViewModels.Services.Interfaces;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IViewModelServices _viewModelServices;
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageServices _imageServices;
        private readonly IOrderServices _orderServices;

        public HomeController(IProductServices productServices,
            IMapper mapper,
            IViewModelServices viewModelServices,
            IHttpContextAccessor httpContextAccessor,
            IImageServices imageServices,
            IOrderServices orderServices)
        {
            this._orderServices = orderServices;
            this._productServices = productServices;
            this._mapper = mapper;
            this._viewModelServices = viewModelServices;
            this._httpContextAccessor = httpContextAccessor;
            this._imageServices = imageServices;
        }
        [HttpGet]
        [Obsolete]
        public async Task<IActionResult> Home()
        {
            var products = await this._productServices.GetAllAsync();
            var images = await this._imageServices.GetAllAsync();

            var ProductViewBag = _viewModelServices.SetProductCollection(products);
            var ImageViewBag = _viewModelServices.SetImageCollection(images);
            var UserId = Request.Cookies["UserID"];
            var UserOrders =await _orderServices.GetUserOrdersAsync(UserId);
            var UserOrdersAsList = _viewModelServices.SetUserOrdersCollection(UserOrders);

            if (Request.Cookies["CookieCart"] != null)
            {

                var CookieCart = JsonConvert.DeserializeObject<List<Item>>(Request.Cookies["CookieCart"]);
                ViewBag.cart = CookieCart;
            }

            ViewBag.userOrders = UserOrdersAsList;
            ViewData["Products"] = ProductViewBag;
            ViewData["Images"] = ImageViewBag;


            return View();
        }

    }
}
