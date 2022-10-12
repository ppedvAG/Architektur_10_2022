using FluentValidation;
using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Application.ValidationService
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Price).GreaterThan(0).WithSeverity(Severity.Error);
            RuleFor(x => x.Weight).GreaterThan(0);
            RuleFor(x => x.Weight).Must(x => x < 50).WithMessage("So schwer kann doch nichts sein!");
        }
    }
}