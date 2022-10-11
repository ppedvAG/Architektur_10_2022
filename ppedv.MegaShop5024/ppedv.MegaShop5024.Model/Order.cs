namespace ppedv.MegaShop5024.Model
{
    public class Order : Entity
    {
        public DateTime Date { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

    }
}