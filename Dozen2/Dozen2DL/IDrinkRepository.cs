using Dozen2Models;
using System.Collections.Generic;


namespace Dozen2DL
{
    public interface IDrinkRepository
    {
        List <Drink> GetDrinks();
        
        Drink AddDrink( Drink newDrink);      

        List<Drink> GetDrinksByLocation(int storeCode);
    }
}