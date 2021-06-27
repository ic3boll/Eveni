﻿using ApplicationCore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using Web.Models;
using Web.Models.Order;
using Web.ViewModels.Images;
using Web.ViewModels.Products;

namespace Web.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //ApplicationUser
            CreateMap<ProductViewModel, ProductInputModel>();
            CreateMap<Product, ProductInputModel>();
            CreateMap<ProductInputModel, Product>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ApplicationUser>();
            CreateMap<ApplicationUser, Product>();
            CreateMap<IReadOnlyCollection<Product>, ProductViewModel>();
            CreateMap<ProductViewModel,IReadOnlyCollection< Product>>();
            CreateMap<OrderDetailInputModel, Order_Detail>();
            CreateMap<Order_Detail, OrderDetailInputModel>();
            CreateMap<ImageViewModel, Image>();
            CreateMap<Image, ImageViewModel>();

        }

  
    }
}
