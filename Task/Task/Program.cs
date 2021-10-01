using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of products: ");
            int numberOfProducts = int.Parse(Console.ReadLine());
            Product[] products = new Product[numberOfProducts];
            if (numberOfProducts > 0)
            {
                Console.WriteLine("Enter name, price and weight of each product.");
                for (int i = 0; i < products.Length; ++i)
                {
                    Console.WriteLine($"Product number {i + 1}:");
                    products[i] = new Product(Console.ReadLine(), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                }
                Buy buy = new Buy(products);
                buy.AddProduct();
                Console.WriteLine(Check.Print(buy));
            }
        }
    }
}
