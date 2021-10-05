using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Orders
{
    public class OrderViewModel
    {
        public string CookieID { get; set; }

        public string Items { get; set; }

        public DateTime TimePlaced { get; set; }

        public Order_Detail Order_Detail { get; set; }
    }
}
