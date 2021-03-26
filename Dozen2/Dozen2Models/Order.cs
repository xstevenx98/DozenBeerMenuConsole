namespace Dozen2Models
{
    public class Order
    {
        private int orderID;
        private decimal total;
        private Customer customer;
        private Location location;


        //list of order items aka collection

        public int Quantity { get; set; }

        public string DrinkName { get; set; }

        public Customer Customer 
        {
            get 
            {
                return customer;
            }
            set
            {
                customer = value;
            
            }
        }
        public Location Location 
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
        public decimal Total 
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public int DrinkId { get; set; }

        public int OrderID 
        {
            get{return orderID;}
            set{orderID = value;}
        }

        public override string ToString()
        {
            return $"Order ID: {this.OrderID} \n\tTotal: ${this.Total}";
        }

    }
}