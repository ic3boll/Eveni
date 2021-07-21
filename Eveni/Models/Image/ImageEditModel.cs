using ApplicationCore.Entities;
using ApplicationCore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Image
{
    public class ImageEditModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public ImageEnum imageEnum { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
