using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Services.Interfaces;
using Web.ViewModels.Products;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        public ProductController(IProductServices productServices,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            this._productServices = productServices;
            this._mapper = mapper;
            this._userManager = userManager;

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var productInputModel = _mapper.Map<ProductInputModel>(productViewModel);
            await _productServices.CreateProductAsync(productInputModel,user);
            return View();
        }

    }
}
