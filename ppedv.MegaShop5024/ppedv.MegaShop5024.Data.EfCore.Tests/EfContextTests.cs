using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ppedv.MegaShop5024.Model;
using System.Reflection;
using System.Reflection.Emit;

namespace ppedv.MegaShop5024.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_db()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_add_Product()
        {
            var prod = new Product() { Name = "Ding", Description = "Tolles Teil", Weight = 4.5f, Price = 9.99m };
            var con = new EfContext();

            con.Add(prod);
            var result = con.SaveChanges();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Can_read_Product()
        {
            var prod = new Product() { Name = $"Ding_{Guid.NewGuid()}", Description = "Tolles Teil", Weight = 4.5f, Price = 9.99m };
            using (var con = new EfContext())
            {
                con.Add(prod);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Products.Find(prod.Id);
                Assert.Equal(prod.Name, loaded?.Name);
            }
        }

        [Fact]
        public void Can_update_Product()
        {
            var prod = new Product() { Name = $"Ding_{Guid.NewGuid()}", Description = "Tolles Teil", Weight = 4.5f, Price = 9.99m };
            var newName = $"Zeug_{Guid.NewGuid()}";
            using (var con = new EfContext())
            {
                con.Add(prod);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Products.Find(prod.Id);
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Products.Find(prod.Id);
                Assert.Equal(newName, loaded?.Name);
            }
        }

        [Fact]
        public void Can_delete_Product()
        {
            var prod = new Product() { Name = $"Ding_{Guid.NewGuid()}", Description = "Tolles Teil", Weight = 4.5f, Price = 9.99m };
            using (var con = new EfContext())
            {
                con.Add(prod);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Products.Find(prod.Id);
                con.Products.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Products.Find(prod.Id);
                Assert.Null(loaded);
            }
        }

        [Fact]
        public void Customer_can_not_be_deleted_if_he_has_orders()
        {
            var cust = new Customer() { Name = "Fred" };
            var order = new Order() { Customer = cust };

            using (var con = new EfContext())
            {
                con.Add(order);
                var result = con.SaveChanges();
                Assert.Equal(2, result); //insert cascade
            }

            using (var con = new EfContext())
            {
                var loaded = con.Customers.Find(cust.Id);
                con.Customers.Remove(loaded);
                Assert.Throws<DbUpdateException>(() => con.SaveChanges());
            }
        }

        [Fact]
        public void Customer_can_only_be_deleted_if_all_orders_are_deleted()
        {
            var cust = new Customer() { Name = "Fred" };
            var order = new Order() { Customer = cust };

            using (var con = new EfContext())
            {
                con.Add(order);
                var result = con.SaveChanges();
                Assert.Equal(2, result); //insert cascade
            }

            using (var con = new EfContext())
            {
                var loadedCustomer = con.Customers.Find(cust.Id);
                var loadedOrder = con.Orders.Find(order.Id);
                con.Customers.Remove(loadedCustomer);
                con.Orders.Remove(loadedOrder);
                var result = con.SaveChanges();
                Assert.Equal(2, result);
            }
        }


        [Fact]
        public void Can_read_Product_AutoFix_FluentAssertions()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id), nameof(Entity.Modified), nameof(Entity.Created), nameof(Entity.IsDelete)));
            var prod = fix.Create<Product>();

            using (var con = new EfContext())
            {
                con.Add(prod);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Products.Find(prod.Id);
                loaded.Should().BeEquivalentTo(prod, x => x.IgnoringCyclicReferences());
            }
        }

        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }

    }
}