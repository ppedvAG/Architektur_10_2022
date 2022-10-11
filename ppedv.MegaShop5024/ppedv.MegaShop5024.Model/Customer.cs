﻿namespace ppedv.MegaShop5024.Model
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}