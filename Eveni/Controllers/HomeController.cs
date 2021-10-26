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
            ProductImageViewModel ProductsToAdd = new ProductImageViewModel();
            if(! _cache.TryGetValue("CacheTime", out ProductImageViewModel products))
            { 
         
                products = await _viewModelServices.SetProductsToCache(ProductsToAdd);
                sw.Stop();
                ViewBag.totaltime = sw.Elapsed;
                return View(products);

            }
            ProductsToAdd = _cache.Get<ProductImageViewModel>("CacheTime");
            sw.Stop();
            ViewBag.totaltime = sw.Elapsed;
            return View(ProductsToAdd);
        }

    }
}
