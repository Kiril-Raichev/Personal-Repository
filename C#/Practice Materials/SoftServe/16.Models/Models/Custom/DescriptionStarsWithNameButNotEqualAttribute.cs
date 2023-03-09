using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models.Custom
{
    public class DescriptionStarsWithNameButNotEqualAttribute : ValidationAttribute
    {
        //add validation error to to be above desc field
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var product = context.ObjectInstance as Product;
            //Name and Desc equal check
            if (value != null && value.ToString() == product.Name)
            {
                return new ValidationResult($"{context.MemberName} should not be equal to Name");
            }
            //Starts with Name check
            if (value != null && !value.ToString().StartsWith(product.Name))
            {
                return new ValidationResult($"{context.MemberName} should start with Name");

            }
            return ValidationResult.Success;
        }
    }
}
