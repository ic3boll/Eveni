using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;
using Web.Services.Interfaces;
using Web.ViewModels.Products;

namespace Web.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductServices(IAsyncRepository<Product> productRepository, 
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

  

        public async Task CreateProductAsync(ProductInputModel productInputModel, ApplicationUser user)
        {
            // var userId = user.Id;

            //   var mapUserId = _mapper.Map<ApplicationUser>(user.Id);
            //   var asd = _mapper.Map<Product>(user);
            //    var asdd = user;
            var product = _mapper.Map<Product>(productInputModel);
            //_mapper.Map<Product>(user);
            product.ApplicationUser = user;
         
            // lazy loading bcs i cant find a way to multimap
            var productt = new Product()
            {
                Name = productInputModel.Name,
                Size = productInputModel.Size,
                Color = productInputModel.Color,
                Quantity = productInputModel.Quantity,
                Rate = productInputModel.Rate,
                Sex = productInputModel.Sex,
                Brand = productInputModel.Brand,
                Category = productInputModel.Category,
                ProductPlaced = productInputModel.ProductPlaced,
                ApplicationUser=user
           
                
            };
            await _productRepository.AddAsync(product);
        }

        public async Task<IReadOnlyCollection<Product>> GetAllProducts()
        {
            var products = await this._productRepository.GetAllAsync();
            return products;
        }

    
    }
}
