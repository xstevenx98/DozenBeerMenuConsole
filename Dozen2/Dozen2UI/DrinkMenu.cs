using System;
using Dozen2Models;
using Dozen2BL;
using System.Collections.Generic;
using Dozen2DL;
using DozenBL;
using Dozen2DL.Entities;

namespace Dozen2UI
{
    public class DrinkMenu : IMenu
    {
        private DBSteveIP0Context context;

        public DrinkMenu(DBSteveIP0Context context)
        {
            this.context = context;
        }

        //Drink drink = new Drink();

        public void Start()
        {
            bool startMenu = true;
            do
            {
                Console.WriteLine("Welcome to Dozen! Are you a manager or a customer?");
                Console.WriteLine("[0] Customer Menu"); 
                Console.WriteLine("[1] Manager");
                Console.WriteLine("[2] Exit");

            //get user input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();
                        var drinkrepo = new DrinkRepositoryDB();
                        var mapper = new Mapper();
                        var customerRepo = new CustomerRepoDB(context, mapper);
                        var customerBL = new CustomerBL(customerRepo);
                        var locationRepo = new LocationRepositoryDB(context, mapper);
                        var locationBL = new LocationBL(locationRepo);
                        var orderRepoDB = new OrderRepositoryDB(context, mapper);
                        var orderBL = new OrderBL(orderRepoDB);
                        var inventoryRepoDB = new InventoryRepoDB(context,mapper);
                        var inventoryBL = new InventoryBL(inventoryRepoDB);
                        var drinkBL = new DrinkBL(drinkrepo);
                switch (userInput)
                {
                    case "0" :
                        

                     CustomerMenu customerMenu = new CustomerMenu( drinkBL, customerBL, locationBL, orderBL, inventoryBL  );
                     customerMenu.Start();
                    break;

                    case "1" :
                      ManagerMenu managerMenu = new ManagerMenu(locationBL, orderBL, inventoryBL, customerBL);
                      managerMenu.Start();
                    break;
                
                    case "2" :
                    startMenu = false;
                    break;

                    default: 
                    Console.WriteLine("Invalid input! Try again");
                    break;
                }
            } while (startMenu);
        }

       

        

        // public void MainMenu()
        // {
        //     DrinkMenu dMenu = new DrinkMenu(_customerBL, _locationBL, _drinkBL, _inventoryBL, _orderBL, _drinkOrderBL);
        //     dMenu.Start();
        // }
    }
}