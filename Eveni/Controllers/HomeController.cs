using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Threading.Tasks;
using Web.Services.Intefaces;
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

        public HomeController(IProductServices productServices,
            IMapper mapper,
            IViewModelServices viewModelServices,
            IHttpContextAccessor httpContextAccessor,
            IImageServices imageServices)
        {

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


            ViewData["Products"] = ProductViewBag;
            ViewData["Images"] = ImageViewBag;


            return View();
        }

    }
}
