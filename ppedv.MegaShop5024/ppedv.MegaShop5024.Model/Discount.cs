namespace ppedv.MegaShop5024.Model
{
    public class Discount : Entity
    {
        public string Name { get; set; } = string.Empty; 
        public int Percentange { get; set; }
        public decimal Amount { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}