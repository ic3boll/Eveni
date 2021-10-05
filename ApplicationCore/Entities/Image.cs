using ApplicationCore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public class Image : BaseEntity
    {
        public Image()
        {

        }
        public string ImageUrl { get; set; }

        public ImageEnum imageEnum { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
