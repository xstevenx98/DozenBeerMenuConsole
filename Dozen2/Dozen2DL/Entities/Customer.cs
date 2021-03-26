using System;
using System.Collections.Generic;

#nullable disable

namespace Dozen2DL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
