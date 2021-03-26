using Dozen2DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class InventoryRepoDB : IInventoryRepo
    {
        private DBSteveIP0Context context;
        private Mapper mapper;

        public InventoryRepoDB(DBSteveIP0Context context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Dozen2Models.Drink GetDrinkByName(string drinkName) 
        {
            var entityDrink = context.Drinks.Where(i => i.DrinkName == drinkName).FirstOrDefault();
            Dozen2Models.Drink drink = mapper.ParseDrink(entityDrink);
            return drink;
        }

        public List<Dozen2Models.Location> GetAvailableLocations(string drinkName, int drinkQuantityNumber)
        {
            var locations = new List<Dozen2Models.Location>();
            var drink = context.Drinks.Where(i => i.DrinkName == drinkName).FirstOrDefault();
            if (drink == null)
            {
                return locations;
            }
            else
            {
                var entityInventories = context.Inventories.Where(i => i.DrinkId == drink.DrinkId && i.Quantity >= drinkQuantityNumber).ToList();
                var locationIDs = entityInventories.Select(i => i.LocationId).ToList();
                var entityLocations = context.Locations.Where(i => locationIDs.Contains(i.LocationId)).ToList();
                locations = mapper.ParseLocations(entityLocations);

                return locations;
            }
        }

        public List<Dozen2Models.Inventory> GetLocationInventories(int locationID)
        {
            var entityInventories = context.Inventories
                .Include("Drink")
                .Include("Location")
                .Where(i => i.LocationId == locationID).ToList();
            List<Dozen2Models.Inventory> inventories = mapper.ParseInventories(entityInventories);
            return inventories;
        }
    }
}
