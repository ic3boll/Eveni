using ApplicationCore.Entities.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
      
        public string Name { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public sbyte Rate { get; set; }

        public SexEnum Sex { get; set; }
        
        public double Price { get; set; }

        public string Brand { get; set; }

        public CategoryEnum Category { get; set; }

        public DateTime ProductPlaced { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Image> Images { get; set; }

    }
}
