using ppedv.MegaShop5024.Application.ProductService;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;
using System.Security.Cryptography.X509Certificates;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("*** MegaShop 5024 v0.1 ***");
IRepository repo = new ppedv.MegaShop5024.Data.EfCore.EfRepository();

ProductManager pm = new ProductManager(repo);
var bestProd = pm.GetBestWeightPriceProduct();
Console.WriteLine($"Bestes: {bestProd.Name}");

foreach (var prod in repo.Query<Product>().Where(x => x.Price >= 0).OrderBy(x => x.Name))
{
    Console.WriteLine($"{prod.Name} {prod.Price:c} {prod.Weight}g");
}