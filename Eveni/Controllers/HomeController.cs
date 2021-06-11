using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
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

        public HomeController(IProductServices productServices,
            IMapper mapper,
            IViewModelServices viewModelServices,
            IHttpContextAccessor httpContextAccessor)
        {

            this._productServices = productServices;
            this._mapper = mapper;
            this._viewModelServices = viewModelServices;
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        [Obsolete]
        public async Task<IActionResult> Home()
       {
            var products = await this._productServices.GetAllProducts();
         
              var viewBag = _viewModelServices.SetProductCollection(products);
        
            ViewData["Products"] = viewBag;

            return  View(viewBag);
       }
    
    }
}
