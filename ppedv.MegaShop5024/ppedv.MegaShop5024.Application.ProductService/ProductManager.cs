using ppedv.MegaShop5024.Model;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Application.ProductService
{
    public class ProductManager : IProductManager
    {
        internal IRepository Repository { get; }

        public ProductManager(IRepository repository)
        {
            Repository = repository;
        }

        public Product GetBestWeightPriceProduct()
        {
            return Repository.Query<Product>()
                             .OrderByDescending(x => ((decimal)x.Weight / x.Price))
                             .FirstOrDefault();
        }
    }
}