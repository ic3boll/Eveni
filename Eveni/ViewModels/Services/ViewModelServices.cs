﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Services.Interfaces;
using Web.ViewModels.Products;
using ApplicationCore.Entities;
using Web.ViewModels.Images;

namespace Web.ViewModels.Services
{
    public class ViewModelServices : IViewModelServices
    {
        private readonly IMapper _mapper;
        public ViewModelServices(IMapper mapper)
        {

            this._mapper = mapper;
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

    }
}

