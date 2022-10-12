using Bogus.Bson;
using Microsoft.AspNetCore.Mvc;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.MegaShop5024.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProductController(IRepository repo)
        {
            _repo = repo;
        }
        private ProduktDTO GetDto(Product prd)
        {
            return new ProduktDTO()
            {
                Id = prd.Id,
                Name = prd.Name,
                Description = prd.Description,
                Price = prd.Price,
                Weight = prd.Weight
            };
        }

        private Product GetProd(ProduktDTO prd)
        {
            return new Product()
            {
                Id = prd.Id,
                Name = prd.Name,
                Description = prd.Description,
                Price = prd.Price,
                Weight = prd.Weight
            };
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProduktDTO> Get()
        {
            foreach (var item in _repo.Query<Product>().ToList())
            {
                yield return GetDto(item);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProduktDTO Get(int id)
        {
            return GetDto(_repo.GetById<Product>(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProduktDTO value)
        {
            var prd = GetProd(value);
            _repo.Add(prd);
            _repo.SaveAll();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProduktDTO value)
        {
            var prd = GetProd(value);
            _repo.Update(prd);
            _repo.SaveAll();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var prd = _repo.GetById<Product>(id);
            _repo.Delete(prd);
            _repo.SaveAll();
        }
    }
}
