using ApplicationCore.Entities;
using AutoMapper;
using System.Collections.Generic;
using Web.Models.Order;
using Web.Models.Products;
using Web.ViewModels.Images;
using Web.ViewModels.Products;

namespace Web.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //ProductInputModel-Product
            CreateMap<ProductViewModel, ProductInputModel>();
            CreateMap<Product, ProductInputModel>();

            //ProductEditViewModel-Product
            CreateMap<ProductEditViewModel, Product>();
            CreateMap<Product, ProductEditViewModel>();

            //ProductEditModel-Product
            CreateMap<ProductEditModel, Product>();
            CreateMap<Product, ProductEditModel>();

            //ProductInputModel-Product
            CreateMap<ProductInputModel, Product>();
            CreateMap<ProductViewModel, Product>();

            //Product-ProductViewModel
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            //Product-ApplicationUser
            CreateMap<Product, ApplicationUser>();
            CreateMap<ApplicationUser, Product>();

            //ProductViewModel-IReadOnlyCollection<Product>
            CreateMap<IReadOnlyCollection<Product>, ProductViewModel>();
            CreateMap<ProductViewModel,IReadOnlyCollection< Product>>();

            CreateMap<OrderDetailInputModel, Order_Detail>();
            CreateMap<Order_Detail, OrderDetailInputModel>();

            CreateMap<ImageViewModel, Image>();
            CreateMap<Image, ImageViewModel>();

            CreateMap<ImageEditViewModel, Image>();
            CreateMap<Image, ImageEditViewModel>();

        }

  
    }
}
