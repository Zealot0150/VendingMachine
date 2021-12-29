using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class FruitProduct : BaseProduct
    {
        public FruitProduct(string nameTo, int price)
        {
            productPrice = price;
            name = nameTo;
            identifier = counter++;
        }

        public override string Usage()
        {
           return "Frukter: Man skalar dem vid behov och sedan äter man dem";
        }
    }
}
