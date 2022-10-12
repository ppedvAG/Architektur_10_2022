using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Model.Contracts
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : Entity;
        T? GetById<T>(int id) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;

        int SaveAll();
    }

    public interface IUnitOfWorkQuery
    {
        public IQuery<Product> ProRepoQuery { get; set; }
        //....
        int SaveAll();

    }
    public interface IUnitOfWorkCommand : IUnitOfWorkQuery
    {
        public ICommand<Product> ProRepoCmd { get; set; }
        //....
    }

    public interface IQuery<T> where T : Entity
    {
        IQueryable<T> Query();
        T? GetById(int id);
    }

    public interface ICommand<T> where T : Entity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
