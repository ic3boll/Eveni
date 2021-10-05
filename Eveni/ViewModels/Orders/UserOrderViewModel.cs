using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Item;
using Web.ViewModels.Products;

namespace Web.ViewModels.Orders
{
    public class UserOrderViewModel
    {
        public ItemViewModel items { get; set; }
    }
}
