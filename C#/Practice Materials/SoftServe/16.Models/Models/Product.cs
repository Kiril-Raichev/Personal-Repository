using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsValidation.Models.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    public class Product
    {
        public enum Category { Toy, Technique, Clothes, Transport}
        public int Id { get; set; }
        [EnumDataType(typeof(Category))]
        public Category Type { get; set; } 
        [Required(ErrorMessage = "Name must not be empty!")]
        public string Name { get; set; }
        [MinLength(3, ErrorMessage = "AV:Description must be more than two symbols!")]
        [DescriptionStarsWithNameButNotEqual]
        public string Description { get; set; }
        [Range(0, 100000, ErrorMessage = "Price should be between 0 and 100000!")]
        public decimal Price { get; set; }
    }
}
