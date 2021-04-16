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

            var product = _mapper.Map<Product>(productInputModel);
            product.ApplicationUser = user;

            await _productRepository.AddAsync(product);

        }

        public async Task<IReadOnlyCollection<Product>> GetAllProducts()
        {
            var products = await this._productRepository.GetAllAsync();
            return products;
        }

    
    }
}
