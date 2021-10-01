using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    class Buy
    {
        public Product[] products;
        private int countOfProducts;
        private double totalPrice;
        private double totalWeight;

        public Buy()
        {
            products = null;
            countOfProducts = 0;
            totalPrice = 0;
            totalWeight = 0;
        }
        public Buy(Product[] products)
        {
            this.products = new Product[products.Length];
            this.countOfProducts = products.Length;
            for (int i = 0; i < countOfProducts; ++i)
            {
                this.products[i] = new Product();
                this.products[i].Name = products[i].Name;
                this.products[i].Price = products[i].Price;
                this.products[i].Weight = products[i].Weight;
                totalPrice += products[i].Price;
                totalWeight += products[i].Weight;
            }
        }
        public void AddProduct()
        {
            Console.WriteLine("If you want to add product to the list, press y, if not press any key");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key==ConsoleKey.Y)
            {
                Console.WriteLine("Enter product name, price and weight:");
                Product product = new Product(Console.ReadLine(), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                Product[] products = new Product[CountOfProducts];
                for (int i = 0; i < CountOfProducts; ++i)
                {
                    products[i] = new Product();
                    products[i].Name = this.products[i].Name;
                    products[i].Price = this.products[i].Price;
                    products[i].Weight = this.products[i].Weight;
                }
                ++CountOfProducts;
                this.products = new Product[CountOfProducts];
                for (int i = 0; i < (CountOfProducts - 1); ++i)
                {
                    this.products[i] = new Product();
                    this.products[i].Name = products[i].Name;
                    this.products[i].Price = products[i].Price;
                    this.products[i].Weight = products[i].Weight;
                }
                this.products[CountOfProducts - 1] = new Product(product.Name, product.Price, product.Weight);
                totalPrice += product.Price;
                totalWeight += product.Weight;
            }
        }
        public int CountOfProducts
        {
            get { return countOfProducts; }
            set { countOfProducts = value; }
        }
        public double TotalPrice
        { 
            get { return totalPrice; }
        }
        public double TotalWeight
        { 
            get { return totalWeight; } 
        }
    }
}
