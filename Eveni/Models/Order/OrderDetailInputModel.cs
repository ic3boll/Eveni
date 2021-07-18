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

        [Display(Name = "Personal Name")]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
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
