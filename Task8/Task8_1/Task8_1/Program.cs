using System;
using System.Collections.Generic;

namespace Task8_1
{
    class Program
    {
        static void Print(object a)
        {
            Console.WriteLine(a);
        }
        static int SortingProductsByName(object firstObject, object secondObject)
        {
            if ((firstObject is Product firstProduct) && (secondObject is Product secondProduct))
            {
                if (firstProduct.Name.CompareTo(secondProduct.Name) > 0)
                    return 1;
                else
                    return 0;
            }
            else
                throw new FormatException("Incorrect type for sorting");
        }
        static int SortingProductsByPrice(object firstObject, object secondObject)
        {
            if ((firstObject is Product firstProduct) && (secondObject is Product secondProduct))
            {
                if (firstProduct.Price.CompareTo(secondProduct.Price) > 0)
                    return 1;
                else
                    return 0;
            }
            else
                throw new FormatException("Incorrect type for sorting");
        }
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Snikers", 80, 120, 200, "15.09.2021"));
            list.Add(new Product("Water", 15, 900, 270, "30.09.2021"));
            list.Add(new Product("Apple", 30, 800, 50, "17.10.2021"));
            list.Add(new Product("Bounty", 70, 90, 220, "08.09.2021"));

            Product[] array = new Product[list.Count];
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = list[i];
            }
            Console.WriteLine("Array before sorting:");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i].ToString());
            }

            Sorting.Sort(array, SortingProductsByName);
            Console.WriteLine("\nArray after sorting by name:");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i].ToString());
            }

            Sorting.Sort(array, SortingProductsByPrice);
            Console.WriteLine("\nArray after sorting by price:");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i].ToString());
            }
        }
    }
}
