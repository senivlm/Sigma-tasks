using System;

namespace SetOfDishes
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOfProducts listOfProducts = new ListOfProducts(@"./set of dishes.txt", @"./price tag.txt");
            Console.WriteLine(listOfProducts.GetListOfProducts());
        }
    }
}
