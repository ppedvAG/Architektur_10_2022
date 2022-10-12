using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Data.EfCore
{
    public class EfRepository : IRepository
    {
        private readonly EfContext _context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if(typeof(T) == typeof(Product))
            //    _context.Products.Add(entity as Product); 

            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public int SaveAll()
        {
            return _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Set<T>().Update(entity);
        }
    }
}
