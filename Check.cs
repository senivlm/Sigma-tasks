using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    class Check
    {
        static public string Print(Buy buy)
        {
            string result = "";
            for (int i = 0; i < buy.CountOfProducts; ++i)
            {
                result += "Name: " + buy.products[i].Name + ", price = " + buy.products[i].Price + ", weight: " + buy.products[i].Weight + "\n";
            }

            result += "Total weight: " + buy.TotalWeight + "\nTotal price: " + buy.TotalPrice + "\n";
            return result;
        }
    }
}
