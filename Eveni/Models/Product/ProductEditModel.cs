﻿using ApplicationCore.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Product
{
    public class ProductEditModel
    {
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