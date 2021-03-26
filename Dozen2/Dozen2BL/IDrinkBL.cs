using Dozen2Models;
using System.Collections.Generic;

namespace Dozen2BL
{
    public interface IDrinkBL
    {
        List <Drink> GetDrinks();
        void AddDrink(Drink newDrink);

        List<Drink> GetDrinksByLocation(int storeCode);
    }
}