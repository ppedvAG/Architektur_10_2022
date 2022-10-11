namespace ppedv.MegaShop5024.Model
{
    public class Product : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Weight { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();


    }
}