using Dozen2DL;
using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2BL
{
    public class InventoryBL : IInventoryBL
    {
        private InventoryRepoDB inventoryRepoDB;

        public InventoryBL(InventoryRepoDB inventoryRepoDB)
        {
            this.inventoryRepoDB = inventoryRepoDB;
        }

        public List<Location> GetAvailableLocations(string drinkName, int drinkQuantityNumber)
        {
            return inventoryRepoDB.GetAvailableLocations(drinkName, drinkQuantityNumber);
        }

        public Drink GetDrinkByName(string drinkName)
        {
            return inventoryRepoDB.GetDrinkByName(drinkName);
        }

        public List<Inventory> GetLocationInventories(int locationID)
        {
            return inventoryRepoDB.GetLocationInventories(locationID);
        }
    }
}
