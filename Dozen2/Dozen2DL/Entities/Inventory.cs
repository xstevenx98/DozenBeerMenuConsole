using System;
using System.Collections.Generic;

#nullable disable

namespace Dozen2DL.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int DrinkId { get; set; }
        public int LocationId { get; set; }
        public int Quantity { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Location Location { get; set; }
    }
}
