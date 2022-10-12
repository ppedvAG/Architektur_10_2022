using Bogus;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;


namespace ppedv.MegaShop5024.Application.DemoDatenService
{
    public class DemoManager : IDemoManager
    {
        public DemoManager(IRepository repo)
        {
            Repo = repo;
        }

        internal IRepository Repo { get; }

        public void CreateAndStoreDemoDaten()
        {
            var catFaker = new Faker<Category>().UseSeed(5);
            catFaker.RuleFor(x => x.Name, x => x.Commerce.Categories(1).First());
            var cats = catFaker.Generate(10);

            var prodFaker = new Faker<Product>().UseSeed(5);
            prodFaker.RuleFor(x => x.Name, x => x.Commerce.ProductName());
            prodFaker.RuleFor(x => x.Description, x => x.Commerce.Department());
            prodFaker.RuleFor(x => x.Price, x => x.Random.Decimal(0.5m, 100));
            prodFaker.RuleFor(x => x.Weight, x => x.Random.Float(0.5f, 100));
            prodFaker.RuleFor(x => x.Categories, x => x.PickRandom(cats, 3).ToList());

            foreach (var item in prodFaker.Generate(100))
            {
                Repo.Add(item);
            }
            Repo.SaveAll();
        }
    }
}