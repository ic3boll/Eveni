using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            var picture = _imageHelper.ImageUpload(productViewModel.ImageFile.OpenReadStream());
            var user = await _userManager.GetUserAsync(User);
            var productInputModel = _mapper.Map<ProductInputModel>(productViewModel);
            await _productServices.CreateProductAsync(productInputModel,user, picture);
            return View();
        }

        public async Task<IActionResult> Update()
        {

            return View();
        }
    }
}
