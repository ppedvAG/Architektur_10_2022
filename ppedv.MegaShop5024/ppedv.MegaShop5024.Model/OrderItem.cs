namespace ppedv.MegaShop5024.Model
{
    public class OrderItem : Entity
    {
        public double Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
    }
}