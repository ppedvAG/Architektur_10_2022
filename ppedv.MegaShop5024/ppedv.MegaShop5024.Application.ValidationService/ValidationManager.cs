using FluentValidation.Results;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Application.ValidationService
{
    public class ValidationManager : IValidationManager
    {
        readonly ProductValidator _proVali = new ProductValidator();

        public bool ValidateProduct(Product prod)
        {
            return _proVali.Validate(prod).IsValid;
        }
    }
}
