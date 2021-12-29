using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public abstract class BaseProduct
    {
        protected static int counter = 0;
        protected int identifier;
        protected string name = "";
        protected  int productPrice = 0;


        public int GetPrice()
        { 
           return productPrice;
        }

        public int GetId()
        {
            return identifier;
        }

        public abstract string Usage();

        public override string ToString()
        {
            return identifier + " " + name + " pris:" + GetPrice() ; 
        }
    }
}
