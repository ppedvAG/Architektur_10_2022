using FluentValidation.Results;
using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Model.Contracts
{
    public interface IValidationManager
    {
        ValidationResult ValidateProduct(Product prod);
    }
}