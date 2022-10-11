using ppedv.MegaShop5024.Application.ProductService;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("*** MegaShop 5024 v0.1 ***");
IRepository repo = new ppedv.MegaShop5024.Data.EfCore.EfRepository();

ProductManager pm = new ProductManager(repo);
var bestProd = pm.GetBestWeightPriceProduct();
Console.WriteLine($"Bestes: {bestProd.Name}");

foreach (var prod in repo.GetAll<Product>())
{
    Console.WriteLine($"{prod.Name} {prod.Price:c} {prod.Weight}g");
}