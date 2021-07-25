using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
using Web.Models.Products;
using Web.Services.Interfaces;
using Web.ViewModels.Products;
using Web.ViewModels.Services.Interfaces;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;
        private readonly IImageServices _imageServices;
        private readonly IViewModelServices _viewModelServices;
        public ProductController(IProductServices productServices,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IImageHelper imageHelper,
            IImageServices imageServices,
            IViewModelServices viewModelServices)
        {
            this._productServices = productServices;
            this._mapper = mapper;
            this._userManager = userManager;
            this._imageHelper = imageHelper;
            this._imageServices = imageServices;
            this._viewModelServices = viewModelServices;
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

            await _productServices.CreateAsync(productInputModel, user, picture);
            return View();
        }
        public async Task<IActionResult> Index(int id)
        {
            var product = await _productServices.GetIdAsync(id);
            var image = await _imageServices.GetAllAsync();

           // var imageC = _viewModelServices.SetImageCollection(image).Where(i => i.ProductId == id);

            var productImage = _viewModelServices.SetProductImageCollection(image,id);
            
            

           ViewData["Product"]= _mapper.Map<ProductViewModel>(product);
            ViewData["Images"] = productImage;

            return View(product);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productId = await _productServices.GetIdAsync(id);
            var images = await _imageServices.GetProductImage(id);

            var productViewModel = _mapper.Map<ProductEditViewModel>(productId);
            var productImage = _viewModelServices.EditProductImageCollection(images, id);

            ViewData["Images"] = productImage;
            ViewData["Product"] = productViewModel;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditModel productEditModel, int id)
        {
            if(productEditModel.ImageFile != null)
            {

                var picture = _imageHelper.ImageUpload(productEditModel.ImageFile.OpenReadStream());

                await _productServices.EditAsync(productEditModel, picture, id);
            }
           
            await _productServices.EditAsync(productEditModel, id);

            return RedirectToAction("Home", "Home");
        }
        
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _productServices.DeleteAsync(id);

            return RedirectToAction("Home", "Home");
        }
        

        [Authorize]
        public async Task<IActionResult> RemoveImage(int id)
        {
            await _imageServices.RemoveImage(id);
            return RedirectToAction("AllProducts", "Manager");
        }


    }
}
