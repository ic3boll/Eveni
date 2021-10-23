using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Images;

namespace Web.ViewModels.Products
{
    public class ProductImageViewModel
    {
        public List<ProductViewModel> Products { get; set; }

        public List<ImageViewModel> Images { get; set; }
        public ProductImageViewModel()
        {
            this.Products = new List<ProductViewModel>();
            this.Images = new List<ImageViewModel>();
        }
    }
}
