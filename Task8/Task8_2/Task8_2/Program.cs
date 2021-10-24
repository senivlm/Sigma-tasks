using System;
using System.Collections.Generic;

namespace Task8_2
{
    class Program
    {
        static List<Product> CommonProducts(Storage firstStorage, Storage secondStorage)
        {
            List<Product> result = new List<Product>();
            Dictionary<string, Product> commonProducts = new Dictionary<string, Product>();
            for (int i = 0; i < firstStorage.Products.Count; ++i)
            {
                for (int j = 0; j < secondStorage.Products.Count; ++j)
                {
                    if (firstStorage[i].Name == secondStorage[j].Name)
                    {
                        if (!commonProducts.ContainsKey(firstStorage[i].Name))
                        {
                            commonProducts.Add(firstStorage[i].Name, firstStorage[i]);
                        }
                    }
                }
            }
            foreach (KeyValuePair<string, Product> item in commonProducts)
            {
                result.Add(item.Value);
            }
            return result;
        }
        static List<Product> UniqueProductsInFirstStorage(Storage firstStorage, Storage secondStorage)
        {
            List<Product> result = new List<Product>();
            Dictionary<string, Product> uniqueProductsInFirstStorage = new Dictionary<string, Product>();
            for (int i = 0; i < firstStorage.Products.Count; ++i)
            {
                if (!uniqueProductsInFirstStorage.ContainsKey(firstStorage[i].Name))
                {
                    uniqueProductsInFirstStorage.Add(firstStorage[i].Name, firstStorage[i]);
                }
            }
            for (int i = 0; i < secondStorage.Products.Count; ++i)
            {
                if (uniqueProductsInFirstStorage.ContainsKey(secondStorage[i].Name))
                {
                    uniqueProductsInFirstStorage.Remove(secondStorage[i].Name);
                }
            }
            foreach (KeyValuePair<string, Product> item in uniqueProductsInFirstStorage)
            {
                result.Add(item.Value);
            }
            return result;
        }
        static List<Product> DifferentProducts(Storage firstStorage, Storage secondStorage)
        {
            List<Product> result = new List<Product>();
            Dictionary<string, Product> differentProducts = new Dictionary<string, Product>();
            for (int i = 0; i < firstStorage.Products.Count; ++i)
            {
                if (!differentProducts.ContainsKey(firstStorage[i].Name))
                {
                    differentProducts.Add(firstStorage[i].Name, firstStorage[i]);
                }
            }
            for (int i = 0; i < secondStorage.Products.Count; ++i)
            {
                if (differentProducts.ContainsKey(secondStorage[i].Name))
                {
                    differentProducts.Remove(secondStorage[i].Name);
                }
                else
                {
                    differentProducts.Add(secondStorage[i].Name, secondStorage[i]);
                }
            }
            foreach (KeyValuePair<string, Product> item in differentProducts)
            {
                result.Add(item.Value);
            }
            return result;
        }
        static void Main(string[] args)
        {
            Storage firstStorage = new Storage();
            firstStorage.Products.Add(new Product("Apple", 15, 900, 30, "30.09.2021"));
            firstStorage.Products.Add(new Product("Juice", 40, 800, 80, "10.09.2021"));
            firstStorage.Products.Add(new Product("Snikers", 70, 90, 300, "15.10.2021"));
            firstStorage.Products.Add(new Product("Water", 20, 900, 180, "20.09.2021"));
            Console.WriteLine(firstStorage.ToString());
            Storage secondStorage = new Storage();
            secondStorage.Products.Add(new Product("Snikers", 80, 100, 250, "16.09.2021"));
            secondStorage.Products.Add(new Product("Orange", 30, 900, 70, "14.10.2021"));
            secondStorage.Products.Add(new Product("Apple", 17, 800, 40, "27.09.2021"));
            Console.WriteLine(secondStorage.ToString());
            ProductSearch productSearch = new ProductSearch();
            productSearch.RegisterDelegate(CommonProducts);
            List<Product> result1 = productSearch.Del(firstStorage, secondStorage);
            for (int i = 0; i < result1.Count; ++i)
            {
                Console.WriteLine(result1[i].ToString());
            }
            productSearch.RemoveDelegate(CommonProducts);
            productSearch.RegisterDelegate(UniqueProductsInFirstStorage);
            List<Product> result2 = productSearch.Del(firstStorage, secondStorage);
            Console.WriteLine();
            for (int i = 0; i < result2.Count; ++i)
            {
                Console.WriteLine(result2[i].ToString());
            }
            productSearch.RemoveDelegate(UniqueProductsInFirstStorage);
            productSearch.RemoveDelegate(CommonProducts);
            productSearch.RegisterDelegate(DifferentProducts);
            List<Product> result3 = productSearch.Del(firstStorage, secondStorage);
            Console.WriteLine();
            for (int i = 0; i < result3.Count; ++i)
            {
                Console.WriteLine(result3[i].ToString());
            }
        }
    }
}
