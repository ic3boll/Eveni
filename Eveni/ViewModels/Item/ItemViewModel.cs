using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Products;

namespace Web.ViewModels.Item
{
    public class ItemViewModel
    {
        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
