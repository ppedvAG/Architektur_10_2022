namespace ppedv.MegaShop5024.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDelete { get; set; }
    }

    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }

    public class Order : Entity
    {
        public DateTime Date { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

    }

    public class Discount : Entity
    {
        public string Name { get; set; } = string.Empty; 
        public int Percentange { get; set; }
        public decimal Amount { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }

    public class OrderItem : Entity
    {
        public double Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Product? Product { get; set; }

    }

    public class Product : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Weight { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();


    }

    public class Category : Entity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}