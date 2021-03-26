using System;
using Dozen2Models;
using Dozen2BL;
using System.Collections.Generic;
using System.Linq;

namespace Dozen2UI
{
    public class BeerMenu : IMenu
    {
        Drink drink = new Drink();
        private IInventoryBL _inventoryBL;
        private IOrderBL _orderBL;
        public BeerMenu(IInventoryBL inventoryBL, IOrderBL orderBL)
        {
            this._inventoryBL = inventoryBL;
            this._orderBL = orderBL;
        }

        public void Start()
        {
            bool startBeerMenu = true;
            do
            {
                Console.WriteLine($"Hello {Program.currentCustomer.Name} !");
                Console.WriteLine("What kind of Beer would you like?");
                //look up order history
                Console.WriteLine("[0] Lager");
                Console.WriteLine("[1] Stout");
                Console.WriteLine("[2] Ale");
                Console.WriteLine("[3] Back");

                Console.WriteLine("Enter a number: ");
                string beerInput = Console.ReadLine();

                switch (beerInput)
                {
                    case "0" :
                        CreateLager();
                        break;
                
                    case "1" : 
                        CreateStout();
                        break;

                    case "2" :
                        CreateAle();
                        break;
                    case "3" :
                       
                        startBeerMenu = false;
                        break;
            

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            } while (startBeerMenu);   
            
           
        }

        public void CreateAle()
        {
            drink.DrinkName = "Ale";
            drink.ABV = 9;
            drink.Price = 8.00m;
            EnterQuantity();
        }

        public void CreateStout()
        {
            drink.DrinkName = "Stout";
            drink.ABV = 12;
            drink.Price = 10.00m;
            EnterQuantity();
        }

        public void CreateLager()
        {
            drink.DrinkName = "Lager";
            drink.ABV = 6;
            drink.Price = 5.00m;
            EnterQuantity();
        }

        public void PlaceOrder(Location location, decimal total, int drinkID, int drinkQuantityNumber)
        {
            var order = new Dozen2Models.Order
            {
                Customer = Program.currentCustomer,
                Location = location,
                Total = total,
                DrinkId = drinkID,
                Quantity = drinkQuantityNumber
                
            };
            _orderBL.AddOrder(order);
            Console.WriteLine("Your order has been successfully placed!");
        }

        public void EnterQuantity()
        {
            Console.WriteLine($"You selected {drink.DrinkName}, which has {drink.ABV}% ABV and costs {drink.Price.ToString("c2")}");
            Console.WriteLine("How many would you like?");
            string drinkQuantity = Console.ReadLine();
            int drinkQuantityNumber = int.Parse(drinkQuantity);
            List<Location> locations = _inventoryBL.GetAvailableLocations(drink.DrinkName, drinkQuantityNumber);
            drink = _inventoryBL.GetDrinkByName(drink.DrinkName);
            if (locations.Any()) 
            {
                if (locations.Count == 1)
                {
                    var location = locations.First();
                    var total = drinkQuantityNumber * drink.Price;
                    Console.WriteLine($"We can fulfill your order from {location.State}, {location.LocationName}. ");
                    Console.WriteLine($"Your total is: ${total}.  Would you like to proceed?  Y/N ");
                    string userChoice = Console.ReadLine();
                    if(userChoice == "Y" || userChoice == "y")
                    {
                        PlaceOrder(location, drinkQuantityNumber * drink.Price, drink.DrinkId, drinkQuantityNumber);

                    }
                }

                else
                {
                    int count = 1;
                    foreach (var item in locations)
                    {
                        Console.WriteLine($"{count} - Name: {item.LocationName} State: {item.State} ");
                        count++;
                    }
                    Console.WriteLine($"Multiple matches found: {locations.Count}, which location would you like to buy from?");

                    string identity = Console.ReadLine();
                    int identityNum = int.Parse(identity);
                    var location = locations.ToArray()[identityNum - 1];

                    PlaceOrder(location, drinkQuantityNumber * drink.Price, drink.DrinkId, drinkQuantityNumber);

                }
            }

            else 
            {
                Console.Write("The drink you would like to order is out of stock.  Please lower your quantity or select a different beer");
            }
        }
    }
}