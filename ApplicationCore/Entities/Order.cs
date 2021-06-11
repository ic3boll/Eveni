using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
   public class Order : BaseEntity
    {
        //ID
        //Cookie-ID
        //list Items

        public string CookieID { get; set; }

        public string Items { get; set; } 

     //   public int? Order_Detail_ID { get; set; }
        public Order_Detail Order_Detail { get; set; }
    }
}
