using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Order
{
    public class OrderDetailInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
       
        public string Comment { get; set; }
    }
}
