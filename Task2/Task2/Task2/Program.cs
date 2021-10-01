using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.AddListOfProducts();
            Console.WriteLine("Fill the storage with a dialog with the user:");
            Console.WriteLine(storage.Print());
            Product[] products = new Product[3];
            products[0] = new Product("Surprise", 43, 120);
            products[1] = new Meat("Pork", 160, 1000, Kind.Pork, Category.HighestGrade);
            products[2] = new Dairy_products("Radimo", 21, 900, 2);
            Storage storage2 = new Storage(products);
            Console.WriteLine("\nFill the storage with initialization:");
            Console.WriteLine(storage2.Print());
            Meat[] meat;
            storage2.SearchForMeatProducts(out meat);
            Console.WriteLine("\nFound meat products:");
            for (int i = 0; i < meat.Length; ++i)
            {
                Console.WriteLine(meat[i].ToString());
            }
            storage2.ChangePrice(20);
            Console.WriteLine("\nChange the price of all products in the second storage:");
            Console.WriteLine(storage2.Print());
        }
    }
}
