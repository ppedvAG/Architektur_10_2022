using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.UI.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository _repo;

        public ProductController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_repo.Query<Product>().ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetById<Product>(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View(new Product() { Name = "NEU", Weight = 12 });
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                _repo.Add(prod);
                _repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetById<Product>(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product prod)
        {
            try
            {
                _repo.Update(prod);
                _repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.GetById<Product>(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product prod)
        {
            try
            {
                _repo.Update(prod);
                _repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
