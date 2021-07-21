using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Services.Interfaces;
using Web.ViewModels.Services.Interfaces;

namespace Web.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IProductServices _productService;
        private readonly IViewModelServices _viewModelService;
        private readonly IImageServices _imageService;
        public ManagerController(IProductServices productService,
            IImageServices imageService,
            IViewModelServices viewModelService)
        {
            this._productService = productService;
            this._imageService = imageService;
            this._viewModelService = viewModelService;
        }
        [Authorize]
        [HttpGet]
        public  IActionResult Index()
        {
           

            return View();
        }
        [Authorize]
        public async Task<IActionResult> AllProducts()
        {
            var products = await this._productService.GetAllAsync();
            var images = await this._imageService.GetAllAsync();

            var ProductViewBag = _viewModelService.SetProductCollection(products);
            var ImageViewBag = _viewModelService.SetImageCollection(images);


            ViewData["Products"] = ProductViewBag;
            ViewData["Images"] = ImageViewBag;

            return View();

        }
    }
}
