using Moq;
using ppedv.MegaShop5024.Model.Contracts;
using ppedv.MegaShop5024.Model.DomainModel;

namespace ppedv.MegaShop5024.Application.ProductService.Tests
{
    public class ProductManagerTests
    {
        [Fact]
        public void GetBestWeightPriceProduct_3_products_result_p2_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Product>()).Returns(() =>
            {
                var p1 = new Product() { Name = "p1", Weight = 1, Price = 1 };
                var p2 = new Product() { Name = "p2", Weight = 2, Price = 1 };
                var p3 = new Product() { Name = "p3", Weight = 1, Price = 2 };

                return new[] { p1, p2, p3 }.AsQueryable();
            });
            var pm = new ProductManager(mock.Object);

            var product = pm.GetBestWeightPriceProduct();

            Assert.Equal(product.Name, "p2");
            mock.Verify(x => x.Delete(It.IsAny<Product>()), Times.Never);
            mock.Verify(x => x.Query<Product>(), Times.Once);
        }

        [Fact]
        public void GetBestWeightPriceProduct_3_products_result_p2()
        {
            var pm = new ProductManager(new TestRepo());

            var product = pm.GetBestWeightPriceProduct();

            Assert.Equal(product.Name, "p2");
        }
    }

    public class TestRepo : IRepository
    {
        public IQueryable<T> Query<T>() where T : Entity
        {
            if (typeof(T) == typeof(Product))
            {
                var p1 = new Product() { Name = "p1", Weight = 1, Price = 1 };
                var p2 = new Product() { Name = "p2", Weight = 2, Price = 1 };
                var p3 = new Product() { Name = "p3", Weight = 1, Price = 2 };

                return new[] { p1, p2, p3 }.AsQueryable().Cast<T>();
            }

            throw new NotImplementedException();
        }

        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }


        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}