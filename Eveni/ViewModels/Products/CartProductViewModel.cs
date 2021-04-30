using ApplicationCore.Entities;
using ApplicationCore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services.Interfaces;

namespace Web.ViewModels.Products
{
    public class CartProductViewModel
    {

        public string Name { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public ushort Quantity { get; set; }

        public sbyte Rate { get; set; }

        public SexEnum Sex { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public CategoryEnum Category { get; set; }

        public DateTime ProductPlaced { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
