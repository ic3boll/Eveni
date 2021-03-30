using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
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
        public HomeController(IProductServices productServices,
            IMapper mapper,
            IViewModelServices viewModelServices)
        {

            this._productServices = productServices;
            this._mapper = mapper;
            this._viewModelServices = viewModelServices;
        }
        [HttpGet]
       public async Task<IActionResult> Home()
       {
            var products = await this._productServices.GetAllProducts();
         
              var viewBag = _viewModelServices.SetProductCollection(products);
            ViewData["Products"] = viewBag;
        
           
            return  View(viewBag);
       }
    
    }
}
