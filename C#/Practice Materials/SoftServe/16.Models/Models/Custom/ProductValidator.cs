using FluentValidation;
namespace ProductsValidation.Models.Custom
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().NotNull().WithMessage("Name must not be empty");
            RuleFor(p => p.Description).NotEqual(p=>p.Name).WithMessage("FV:Description and name should not be equal");
            RuleFor(p => p.Description).MinimumLength(2).WithMessage("FV:Description should be more than 2 symbolds");
            RuleFor(p=>p.Price).InclusiveBetween(0,100000).WithMessage("Price should be between 0 and 100000");
        
        }
    }
}
