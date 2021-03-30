using ApplicationCore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Products
{
    public class HomeProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Size { get; set; }

        public sbyte Rate { get; set; }

        public SexEnum Sex { get; set; }

        public string Picture { get; set; }

        public string Brand { get; set; }

        public CategoryEnum Category { get; set; }

    }
}
