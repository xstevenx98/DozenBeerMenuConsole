using System;
using Dozen2Models;
using Dozen2BL;
using System.Collections.Generic;
using Dozen2UI;
using System.Linq;

namespace Dozen2UI
{
    public class CustomerMenu : IMenu
    {
           private ICustomerBL _customerBL;
           private ILocationBL _locationBL;
           private IDrinkBL _drinkBL;
           private IOrderBL _orderBL;
        private IInventoryBL _inventoryBL;
          // DrinkMenu drinkMenu = new DrinkMenu();
           public CustomerMenu(IDrinkBL drinkBL, ICustomerBL customerBL, ILocationBL locationBL, IOrderBL orderBL, InventoryBL inventoryBL)
           {
               _customerBL = customerBL;
              _drinkBL = drinkBL;
              _locationBL = locationBL;
              _orderBL = orderBL;
            _inventoryBL = inventoryBL;
           }
             

        public void Start()
        { 
            bool run = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the Main Menu!");
                Console.WriteLine("Are you a new or an existing customer?");
                Console.WriteLine("[0] - Existing Customer");
                Console.WriteLine("[1] - New Customer");
               // Console.WriteLine("[2] - Place an Order (Existing Customers)"); 
             //   Console.WriteLine("[3] - Select a Store Location");
                Console.WriteLine("[2] - Back");
                //Console.WriteLine("[5] - Main Menu");
                Console.WriteLine("----------------------------------------");
                string selection = Console.ReadLine();

                switch(selection)
                {
                    case "0" :
                        GetCustomers();
                        break;
                    case "1" :
                        CreateCustomer();
                        break;
                    case "3" :
                        BeerMenu beerMenu = new BeerMenu(_inventoryBL, _orderBL);
                        beerMenu.Start();
                        break;
                    case "4" :
                        GetStores();
                        break;
                    case "2" :
                       
                        run = false;
                        break;

                   // case "5" :
                      //  drinkMenu.MainMenu();
                     //   break;
                    default :
                        Console.WriteLine("Invalid! Try again");
                        break;
                } 

            } while (run);
        }

        public Customer SearchCustomer()
        {
            Console.WriteLine("Enter customer's FirstName LastName: ");
            string name = Console.ReadLine();
            int check = 0;
            foreach (var element in _customerBL.GetCustomers())
            {
                if (element.Name == name)
                {
                    return element;
                }

            }
            if (check == 0)
            {
                Console.WriteLine("Matching customer not found");
            }

            Customer nullCustomer = null;
            return nullCustomer;
        }

        public void GetOrders()
        {
            foreach (var element in _orderBL.GetOrders() )
            {
                Console.WriteLine(element.OrderID);
            }
        }
        public void GetPastOrders()
        {
            Customer customer = FindCustomer();
        }

        public Customer FindCustomer()
        {
            Console.WriteLine("Enter customer's full name [FirstName LastName]: ");
            string name = Console.ReadLine();
            int exists = 0;
            foreach (var element in _customerBL.GetCustomers())
            {
                if(element.Name == name)
                {
                    return element;
                }
            }
        
            if (exists == 0)
            {
                Console.WriteLine("This customer doesn't exist.");
            }
            Customer nullCustomer = null;
            return nullCustomer;
        }

        public void CreateCustomer()
        {  
            Console.WriteLine("Cheers! Welcome to the Dozen family!");
            Console.WriteLine("_____________________________________");
            Customer customer = new Customer();  
            Console.WriteLine("Enter your age");
            customer.Age =Console.ReadLine()  ; 
            
            
            if( int.Parse( customer.Age ) < 21 )
            {
                Console.WriteLine("You aren't old enough!");
                return;
            }
            else
            {
              
                Console.WriteLine("Enter your full name [FirstName LastName]");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Enter your phone number");
                customer.PhoneNumber = Console.ReadLine();
                Program.currentCustomer =_customerBL.AddCustomer(customer);
                Console.WriteLine("Customer successfully added!");
                var beermenu = new BeerMenu(_inventoryBL, _orderBL);
                beermenu.Start();
            }
            
        }

        public void GetCustomers()
        {
            Console.WriteLine("Enter your full name");
            string name = Console.ReadLine();
            var customers = _customerBL.GetCustomersByName(name);
            if (customers.Any()) 
            {
                if (customers.Count == 1) 
                {
                    Program.currentCustomer = customers.First();
                }

                else 
                {
                    int count = 1;
                    foreach (var item in customers)
                    {
                        Console.WriteLine($"{count} - Name: {item.Name} Age: {item.Age} ");
                        count++;
                    }
                    Console.WriteLine($"Multiple matches found: {customers.Count}, please select the corresponding number to your name");

                    string identity = Console.ReadLine();
                    int identityNum = int.Parse(identity);
                    Program.currentCustomer = customers.ToArray()[identityNum - 1];

                }
                var beermenu = new BeerMenu(_inventoryBL, _orderBL);
                beermenu.Start();
               
            }
            else
            {
                Console.WriteLine("No customer found with those credentials.");
            }
          
        }


            public void GetStores()
            {
                foreach (var element in _locationBL.GetLocations())
                {
                    Console.WriteLine(element.ToString());
                }
                Console.WriteLine("Enter a Store Code: ");
                int storeCode = int.Parse( Console.ReadLine() );
                Location specifiedLocation = _locationBL.GetSpecifiedLocation(storeCode);
                if(specifiedLocation == null)
                {
                    Console.WriteLine("Invalid code.");
                }
                else
                {
                    Console.WriteLine($"{specifiedLocation.LocationName} Inventory: ");
                    foreach (Drink element in _drinkBL.GetDrinksByLocation(storeCode))
                    {
                        Console.WriteLine(element.DrinkName.ToString());
                        //not sure if this will work ^^^^^
                    }

                    Order newOrder = new Order();
                    bool shop = true;
                    List <Drink> drinkCart = new List<Drink>();
                    List<int> quantityInCart = new List<int>();
                    decimal total = 0.0m;
                    do
                    {
                        Console.WriteLine("Select Drink to add to your order");
                        Console.WriteLine("Type 'Submit' when you're finished.");
                        Console.WriteLine("If you wish to cancel, type 'Cancel'");
                        Console.WriteLine("Selection: ");

                        string selection = Console.ReadLine();

                        if (selection == "cancel" || selection == "Cancel")
                        {
                            shop = false;
                        }
                        else if (selection == "submit" || selection == "Submit")
                        {
                            newOrder.Total = total;
                            newOrder.Location = specifiedLocation;
                            Customer customerOrder = FindCustomer();

                            if(customerOrder == null)
                            {
                                Console.WriteLine("cannot find customer");
                            }
                            else
                            {
                                newOrder.Customer = customerOrder;
                            }

                            _orderBL.AddOrder(newOrder);
                        }

                    }while (shop);
                }
            }
    }

}  
 
//add customer  written
//search customer  written
//place order   written
//view order history by location 
//view order history by customer
//view inventory by location
//

