using ppedv.MegaShop5024.Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MegaShop5024.Model.Contracts
{
    public interface IUnitOfWork
    {
        public IRepo<Product> ProRepo { get; set; }
        public ICustomerRepo CustomerRepo { get; set; }
        //....
        int SaveAll();

    }

    public interface ICustomerRepo : IRepo<Customer>
    {
        IEnumerable<Customer> GetGoodCustomer();
    }

    public interface IRepo<T> where T : Entity
    {
        IQueryable<T> Query();
        T? GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
