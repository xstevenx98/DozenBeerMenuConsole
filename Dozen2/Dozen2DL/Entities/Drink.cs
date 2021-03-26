using System;
using System.Collections.Generic;

#nullable disable

namespace Dozen2DL.Entities
{
    public partial class Drink
    {
        public Drink()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int DrinkId { get; set; }
        public int Abv { get; set; }
        public string DrinkName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
