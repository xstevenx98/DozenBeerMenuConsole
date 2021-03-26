using System;

namespace Dozen2Models
{
    public class Drink
    {
        private string drinkName; //private backing field for DrinkName
        private int abv; //private backing field for ABV
        private decimal price; //private backing field for Price

        public string DrinkName
        {
            get{return drinkName;}
            set{drinkName = value;}
        }

        public int ABV
        {
            get{return abv;}
            set{abv = value;}
        }

        public decimal Price
        {
            get{return price;}
            set{price = value;}
        }

        public int DrinkId { get; set; }



    }
}
