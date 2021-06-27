using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;
using Web.Models;
using Web.Services.Interfaces;
using Web.ViewModels.Products;

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

            var product = _mapper.Map<Product>(productInputModel);
            product.ApplicationUser = user;

            var image = new Image();
            image.ImageUrl = picture;
            image.Product = product;
            image.imageEnum = productInputModel.imageEnum;
          
       
            

           // await _productRepository.AddAsync(product);
            await _imageRepository.AddAsync(image);

        }

        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var products = await this._productRepository.GetAllAsync();
            return products;
        }

        public async Task<Product> GetIdAsync(int id)
        {
           var productId =  await _productRepository.GetByIdAsync(id);
            return productId;
        }
    
    }
}
