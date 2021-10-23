using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Web.Services.Interfaces;
using Web.ViewModels.Products;
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
        private IMemoryCache _cache;

        public HomeController(IProductServices productServices,
            IMapper mapper,
            IViewModelServices viewModelServices,
            IHttpContextAccessor httpContextAccessor,
            IImageServices imageServices,
            IOrderServices orderServices,
            IMemoryCache cache)
        {
            this._orderServices = orderServices;
            this._productServices = productServices;
            this._mapper = mapper;
            this._viewModelServices = viewModelServices;
            this._httpContextAccessor = httpContextAccessor;
            this._imageServices = imageServices;
            this._cache = cache;
        }
        [HttpGet]
        [Obsolete]
        public async Task<IActionResult> Home()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ProductImageViewModel Products = new ProductImageViewModel();
            bool Exist = _cache.TryGetValue("CacheTime", out ProductImageViewModel model);
            if (!Exist)
            {
                var products = await this._productServices.GetAllAsync();
                var images = await this._imageServices.GetAllAsync();

                var ListOfProcucts = _viewModelServices.SetProductCollection(products);
                var ListOfImages = _viewModelServices.SetImageCollection(images);


                Products.Products.AddRange(ListOfProcucts);
                Products.Images.AddRange(ListOfImages);
                _cache.Set("CacheTime", Products, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60)));
                sw.Stop();
                ViewBag.totaltime = sw.Elapsed;
                return View(Products);

            }
            Products = _cache.Get<ProductImageViewModel>("CacheTime");
            sw.Stop();
            ViewBag.totaltime = sw.Elapsed;
            return View(Products);
        }

    }
}
