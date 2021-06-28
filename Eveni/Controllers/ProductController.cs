using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
using Web.Models;
using Web.Models.Product;
using Web.Services.Interfaces;
using Web.ViewModels.Products;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;
        public ProductController(IProductServices productServices,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IImageHelper imageHelper)
        {
            this._productServices = productServices;
            this._mapper = mapper;
            this._userManager = userManager;
            this._imageHelper = imageHelper;
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ProductInputModel productInputModel)
        {
            var picture = _imageHelper.ImageUpload(productInputModel.ImageFile.OpenReadStream());
            var user = await _userManager.GetUserAsync(User);
            //   var prodauctInputModel = _mapper.Map<ProductInputModel>(productViewModel);
            
               await _productServices.CreateAsync(productInputModel, user, picture);
            return View();
        }
        public async Task<IActionResult> Edit(ProductInputModel productInputModel)
        {

        }


    }
}
