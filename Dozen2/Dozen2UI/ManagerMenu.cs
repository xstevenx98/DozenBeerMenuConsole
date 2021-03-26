using Dozen2BL;
using DozenBL;
using System;
using System.Collections.Generic;

namespace Dozen2UI
{
    //view order history by location 
    //view order history by customer
    //view inventory by location

    public class ManagerMenu : IMenu
    {
        private LocationBL locationBL;
        private OrderBL orderBL;
        private InventoryBL inventoryBL;
        private CustomerBL customerBL;
        public ManagerMenu(LocationBL locationBL, OrderBL orderBL, InventoryBL inventoryBL, CustomerBL customerBL)
        {
            this.locationBL = locationBL;
            this.orderBL = orderBL;
            this.inventoryBL = inventoryBL;
            this.customerBL = customerBL;
        }

        public void Start()
        {
            bool managerStart = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome Manager!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] - View Order History by Customer");
                Console.WriteLine("[1] - View Order History by Location");
                Console.WriteLine("[2] - View Inventory by Location");
                Console.WriteLine("[3] - Back");
                string managerChoice = Console.ReadLine();

                switch (managerChoice)
                {
                    case "0":
                        ViewHistoryByCustomer();
                        break;
                    case "1":
                        ViewHistoryByLocation();
                        break;
                    case "2":
                        ViewInventoryByLocation();
                        break;
                    case "3":
                        managerStart = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }

            } while (managerStart);
        }

        public void ViewInventoryByLocation()
        {
            var locations = locationBL.GetLocations();
            Console.WriteLine("Select a location");
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"{i} - {locations[i].LocationName} in {locations[i].State}");

            }
            string userChoice = Console.ReadLine();
            int userChoiceNum = int.Parse(userChoice);
            var selectedLocation = locations[userChoiceNum];
            List<Dozen2Models.Inventory> inventories = inventoryBL.GetLocationInventories(selectedLocation.LocationID);

            Console.WriteLine($"Displaying inventories from {selectedLocation.LocationName} in {selectedLocation.State}");
            foreach (var item in inventories)
            {
                Console.WriteLine($"{item.Quantity} {item.Drink.DrinkName} are available at {item.Location.LocationName} in {item.Location.State}");
            }
        }

        public void ViewHistoryByLocation()
        {
            var locations = locationBL.GetLocations();
            Console.WriteLine("Select a location");
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"{i} - {locations[i].LocationName} in {locations[i].State}");

            }
            string userChoice = Console.ReadLine();
            int userChoiceNum = int.Parse(userChoice);
            var selectedLocation = locations[userChoiceNum];
            var orders = orderBL.GetLocationOrder(selectedLocation.LocationID);

            Console.WriteLine($"Displaying orders from {selectedLocation.LocationName} in {selectedLocation.State}");
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Customer.Name} ordered {item.Quantity} {item.DrinkName} from {item.Location.LocationName} in {item.Location.State}");
            }
            //get all locations
            //pick location 
            // display order history from that location

        }

        private void ViewHistoryByCustomer()
        {
            var customers = customerBL.GetCustomers();
            Console.WriteLine("Which customer would you like to view?");
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"{i} - Name: {customers[i].Name} Phone Number: {customers[i].PhoneNumber}");

            }
            string userChoice = Console.ReadLine();
            int userChoiceNum = int.Parse(userChoice);
            var selectedCustomer = customers[userChoiceNum];
            var orders = orderBL.GetCustomerOrders(selectedCustomer.CustomerId);

            Console.WriteLine($"Displaying orders from {selectedCustomer.Name}");
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Customer.Name} ordered {item.Quantity} {item.DrinkName} from {item.Location.LocationName} in {item.Location.State}");
            }
        }
    }
}