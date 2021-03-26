using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2BL
{
    public interface IInventoryBL
    {
        List<Location> GetAvailableLocations(string drinkName, int drinkQuantityNumber);
        public Dozen2Models.Drink GetDrinkByName(string drinkName);

    }
}
