using System;
using System.Collections.Generic;
using Dozen2DL;
using Dozen2Models;

namespace Dozen2BL
{
    public class DrinkBL : IDrinkBL
    {
        private IDrinkRepository _repo;
        public DrinkBL (IDrinkRepository repo)
        {
            _repo = repo;
        }

        public void AddDrink(Drink newDrink)
        {
            _repo.AddDrink(newDrink);
        }

        public List<Drink> GetDrinks()
        {
            //todo add bl
            return _repo.GetDrinks();
        }

        public List<Drink> GetDrinksByLocation(int storeCode)
        {
            return _repo.GetDrinksByLocation(storeCode);
        }
    }
}
