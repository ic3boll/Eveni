using ApplicationCore.Entities;
using ApplicationCore.Entities.Enums;
using ApplicationCore.Interfaces.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Services;
using Xunit;

namespace XUnitTestProject.ServiceTest
{

    public class ProductServicesTest
    {
        private ProductServices _ProductTesting;
        private readonly Mock<IAsyncRepository<Product>> _productRepository = new Mock<IAsyncRepository<Product>>();
        private readonly Mock<IAsyncRepository<Image>> _imageRepository = new Mock<IAsyncRepository<Image>>();
        private readonly IMapper _mapper;


        public ProductServicesTest()
        {
       
                _ProductTesting = new ProductServices(_productRepository.Object, _mapper, _imageRepository.Object);
           
        }

        [Fact]
        public async  void CheckIfGetByIdWorking()
        {
            //Arrange 
            int id = 10;
            var productToCompare = new Product { Id = id };
            _productRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(productToCompare);
            //Actual
            var productById = await  _ProductTesting.GetIdAsync(id);
            //Assert
            Assert.Equal(productToCompare, productById);
        }


    }
}
