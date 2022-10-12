using ppedv.MegaShop5024.Application.ProductService;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;
using System.Reflection;

//DI direkt per Referenz
//IRepository repo = new ppedv.MegaShop5024.Data.EfCore.EfRepository();

//DI per Reflection
var path = @"C:\Users\Fred\source\repos\ppedvAG\Architektur_10_2022\ppedv.MegaShop5024\ppedv.MegaShop5024.Data.EfCore\bin\Debug\net6.0\ppedv.MegaShop5024.Data.EfCore.dll";
var ass = Assembly.LoadFrom(path);
Type typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
IRepository repo = Activator.CreateInstance(typeMitRepo) as IRepository;



Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("*** MegaShop 5024 v0.1 ***");


ProductManager pm = new ProductManager(repo);
var bestProd = pm.GetBestWeightPriceProduct();
Console.WriteLine($"Bestes: {bestProd.Name}");

foreach (var prod in repo.Query<Product>().Where(x => x.Price >= 0).OrderBy(x => x.Name))
{
    Console.WriteLine($"{prod.Name} {prod.Price:c} {prod.Weight}g");
}