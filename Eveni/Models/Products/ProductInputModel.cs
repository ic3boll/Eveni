using ApplicationCore.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Products
{
    public class ProductInputModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Size for this Product"), MaxLength(5)]
        public string Size { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Color for this Product"), MaxLength(20)]
        public string Color { get; set; }
        public ushort Quantity { get; set; }
        public sbyte Rate { get; set; }
        [Required(ErrorMessage = "Choose SEX for this Product")]
        public SexEnum Sex { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="Enter Price for this Product")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Enter Brand for this Product")]
        public string Brand { get; set; }
        [Required(ErrorMessage ="Choose Priority for this Product image")]
        public ImageEnum imageEnum { get; set; }
        [Required(ErrorMessage ="Choose a picture for this Product")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "Choose Category for this Product")]
        public CategoryEnum Category { get; set; }
    }
}
