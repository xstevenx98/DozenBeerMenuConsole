using System;
using System.Collections.Generic;

#nullable disable

namespace Dozen2DL.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int DrinkId { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Drink Drink { get; set; }
        public virtual Location Location { get; set; }
    }
}
