using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class DrinkProducts : BaseProduct
    {
        public DrinkProducts(string nameToSet, int priceToSet)
        {
            name = nameToSet;
            productPrice = priceToSet;
            identifier = counter++; 
        }

        public override string Usage()
        {
           return "Dricka. Öppna korken och drick upp";
        }
    }
}
