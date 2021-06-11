using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Order
{
    public class OrderDetailInputModel
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Comment { get; set; }
    }
}
