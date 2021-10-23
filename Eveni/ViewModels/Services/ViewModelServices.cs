using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Services.Interfaces;
using Web.ViewModels.Products;
using ApplicationCore.Entities;
using Web.ViewModels.Images;
using System.Linq;
using Web.ViewModels.Orders;
using Microsoft.Extensions.Caching.Memory;
using System;
using Web.Services.Interfaces;

namespace Web.ViewModels.Services
{
    public class ViewModelServices : IViewModelServices
    {
        private readonly IMapper _mapper;
        private readonly IProductServices _productServices;
        private readonly IImageServices _imageServices;
        private IMemoryCache _cache;
        public ViewModelServices(IMapper mapper,
            IProductServices productServices,
            IImageServices imageServices,
            IMemoryCache cache)
        {

            this._mapper = mapper;
            this._productServices = productServices;
            this._imageServices = imageServices;
            this._cache = cache;
        }

        public List<ImageViewModel> SetImageCollection(IReadOnlyCollection<Image> images)
        {
            var listOfImages = new List<ImageViewModel>();
            foreach (var item in images)
            {
                var image = _mapper.Map<ImageViewModel>(item);
                listOfImages.Add(image);
            }
            return listOfImages;
        }
        public List<ProductViewModel> SetProductCollection(IReadOnlyCollection<Product> products)
        {

            var listOfProducts = new List<ProductViewModel>();
            foreach (var item in products)
            {
                var product = _mapper.Map<ProductViewModel>(item);
                listOfProducts.Add(product);
            }
            return listOfProducts;
        }

        public List<ImageViewModel> SetProductImageCollection(IReadOnlyCollection<Image> images, int id)
        {
            var listOfImages = new List<ImageViewModel>();
            foreach (var item in images.Where(i=>i.ProductId==id))
            {
                var image = _mapper.Map<ImageViewModel>(item);
                listOfImages.Add(image);
            }
            return listOfImages;
        }

        public List<ImageEditViewModel> EditProductImageCollection(IReadOnlyCollection<Image> images, int id)
        {
            var listOfImages = new List<ImageEditViewModel>();
            foreach (var item in images.Where(i => i.ProductId == id))
            {
                var image = _mapper.Map<ImageEditViewModel>(item);
                listOfImages.Add(image);
            }
            return listOfImages;
        }

        public List<OrderViewModel> SetUserOrdersCollection(IReadOnlyCollection<OrderViewModel> UserOrders)
        {
            var listOfUserOrders = new List<OrderViewModel>();
            foreach (var item in UserOrders)
            {
                listOfUserOrders.Add(item);
            }
            return listOfUserOrders;
        }

        public async Task<ProductImageViewModel> GetProducts(ProductImageViewModel Product)
        {
            var GetProducts = await this._productServices.GetAllAsync();
            var images = await this._imageServices.GetAllAsync();

            var ListOfProcucts = SetProductCollection(GetProducts);
            var ListOfImages = SetImageCollection(images);


            Product.Products.AddRange(ListOfProcucts);
            Product.Images.AddRange(ListOfImages);
            _cache.Set("CacheTime", Product, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60)));
            return Product;
        }

    }
}

