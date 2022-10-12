using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Model.Contracts
{
    public interface IValidationManager
    {
        bool ValidateProduct(Product prod);
    }
}