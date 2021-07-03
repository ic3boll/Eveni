﻿using ApplicationCore.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace Web.Models.Product
{
    public class ProductInputModel
    {
        //    public int Id { get; set; }
        public string Name { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public ushort Quantity { get; set; }

        public sbyte Rate { get; set; }

        public SexEnum Sex { get; set; }

        public double Price { get; set; }

        public string Brand { get; set; }

        public ImageEnum imageEnum { get; set; }

        public IFormFile ImageFile { get; set; }

        public CategoryEnum Category { get; set; }

        public DateTime ProductPlaced { get; set; }
    }
}