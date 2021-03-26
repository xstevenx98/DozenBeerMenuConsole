using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class Mapper : IMapper
    {
        public Entities.Customer ParseCustomer(Dozen2Models.Customer customer)
        {
            var entityCustomer = new Entities.Customer
            {
                Name = customer.Name,
                Age = customer.Age,
                PhoneNumber = customer.PhoneNumber
            };
            return entityCustomer;


        }

        public Entities.Order ParseOrder(Dozen2Models.Order order)
        {
            var entityOrder = new Entities.Order
            {
                OrderId = order.OrderID,
                Total = order.Total,
                DrinkId = order.DrinkId,
                CustomerId = order.Customer.CustomerId,
                LocationId = order.Location.LocationID,
                Quantity = order.Quantity
            };
 
       return entityOrder;
       }

        internal Dozen2Models.Drink ParseDrink(Entities.Drink entityDrink)
        {
            var drink = new Dozen2Models.Drink
            {
                DrinkId = entityDrink.DrinkId,
                DrinkName = entityDrink.DrinkName,
                ABV = entityDrink.Abv,
                Price = entityDrink.Price
            };

            return drink;
        }

        public Dozen2Models.Customer ParseCustomer(Entities.Customer entityCustomer)
        {
            var customer = new Dozen2Models.Customer
            {
                Name = entityCustomer.Name,
                Age = entityCustomer.Age,
                PhoneNumber = entityCustomer.PhoneNumber,
                CustomerId = entityCustomer.CustomerId
            };
            return customer;


        }

        public List<Dozen2Models.Location> ParseLocations(List<Entities.Location> entityLocations)
        {
            var locations = new List<Dozen2Models.Location>();
            foreach (var item in entityLocations)
            {
                Dozen2Models.Location location = ParseLocation(item);
                locations.Add(location);
            }

            return locations;
        }

        internal List<Dozen2Models.Inventory> ParseInventories(List<Entities.Inventory> entityInventories)
        {
            var inventories = new List<Dozen2Models.Inventory>();
            if(entityInventories.Any())
            {
                foreach (var item in entityInventories)
                {
                    Dozen2Models.Inventory inventory = ParseInventory(item);
                    inventories.Add(inventory);
                }
            }
            return inventories;
        }

        private Dozen2Models.Inventory ParseInventory(Entities.Inventory item)
        {
            var inventory = new Dozen2Models.Inventory
            {
                Drink = ParseDrink(item.Drink),
                Location = ParseLocation(item.Location),
                Quantity = item.Quantity
                
            };
            return inventory;
        }

        public Dozen2Models.Location ParseLocation(Entities.Location item)
        {
            var location = new Dozen2Models.Location
            {
                LocationID = item.LocationId,
                LocationName = item.LocationName,
                State = item.State
            };
            return location;
        }

        public List<Dozen2Models.Customer> ParseCustomers(List<Entities.Customer> entityCustomers)
        {
            var customers = new List<Dozen2Models.Customer>();
            if(entityCustomers.Any())
            {
                foreach (var item in entityCustomers)
                {
                    var customer = ParseCustomer(item);
                    customers.Add(customer);
                }

            }
        
            return customers;
        }

        public Dozen2Models.Order ParseOrder(Entities.Order entityOrder) 
        {
            var order = new Dozen2Models.Order
            {
                OrderID = entityOrder.OrderId,
                Customer = ParseCustomer(entityOrder.Customer),
                Quantity = entityOrder.Quantity,
                DrinkId = entityOrder.DrinkId,
                DrinkName = entityOrder.Drink.DrinkName,
                Location = ParseLocation(entityOrder.Location)

            };
            return order;
        }

        public List<Dozen2Models.Order> ParseOrders(List<Entities.Order> entityOrders)
        {
            var orders = new List<Dozen2Models.Order>();
            if (entityOrders.Any())
            {
                foreach (var item in entityOrders)
                {
                    var order = ParseOrder(item);
                    orders.Add(order);
                }
            }
            return orders;
        }
    }
}
