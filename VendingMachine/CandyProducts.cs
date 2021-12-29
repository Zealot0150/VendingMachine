using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class CandyProducts : BaseProduct
    {
        public CandyProducts(string nameTo, int price)
        {
            name = nameTo;
            productPrice = price;
            identifier = counter++;
        }

        public override string Usage()
        {
            return "Candy, use with care, the will kill your teeeth";
        }
    }
}
