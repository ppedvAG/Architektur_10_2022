namespace ppedv.MegaShop5024.Model
{
    public class Category : Entity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}