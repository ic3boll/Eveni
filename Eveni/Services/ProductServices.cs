using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
using Web.Models.Products;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IAsyncRepository<Image> _imageRepository;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;

        public ProductServices(IAsyncRepository<Product> productRepository,
            IMapper mapper,
            IImageHelper imageHelper,
            IAsyncRepository<Image> imageRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _imageHelper = imageHelper;
            _imageRepository = imageRepository;
        }



        public async Task CreateAsync(ProductInputModel productInputModel, ApplicationUser user, string picture)
        {
            DateTime now = DateTime.Now;
            var product = _mapper.Map<Product>(productInputModel);
            product.ProductPlaced = now;
            product.ApplicationUser = user;

            var image = new Image();
            image.ImageUrl = picture;
            image.Product = product;
            image.imageEnum = productInputModel.imageEnum;

            await _imageRepository.AddAsync(image);

        }

        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var products = await this._productRepository.GetAllAsync();
            return products;
        }

        public async Task<Product> GetIdAsync(int id)
        {
            var productId = await _productRepository.GetByIdAsync(id);
            return productId;
        }
        public async Task EditAsync(ProductEditModel productEditModel,int id)
        {
            var productToEdit = await GetIdAsync(id);
            DateTime now = DateTime.Now;


            _mapper.Map(productEditModel, productToEdit);
            productToEdit.ProductPlaced = now;


            await _productRepository.UpdateAsync(productToEdit);
        }

        public async Task EditAsync(ProductEditModel productEditModel, string imageModel, int id)
        {
            var productToEdit = await GetIdAsync(id);
            DateTime now = DateTime.Now;
           

            _mapper.Map(productEditModel, productToEdit);
            productToEdit.ProductPlaced = now;

           var image = new Image();
           image.ImageUrl = imageModel;
           image.Product = productToEdit;
           image.ProductId = id;
           image.imageEnum = productEditModel.imageEnum;

            await _productRepository.UpdateAsync(productToEdit);
            await _imageRepository.AddAsync(image);
        }


        public async Task DeleteAsync(int id)
        {
          var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(product);
        }
    }
}
