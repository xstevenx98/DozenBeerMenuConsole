using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public interface IInventoryRepo
    {
        public Dozen2Models.Drink GetDrinkByName(string drinkName);

    }
}
