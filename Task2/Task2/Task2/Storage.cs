using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Storage
    {
        private Product[] products;
        public Storage() { products = null; }
        public Storage(Product[] products)
        {
            this.products = new Product[products.Length];
            for (int i = 0; i < products.Length; ++i)
            {
                this.products[i] = new Product();
                this.products[i] = products[i].Copy();
            }
        }
        public void AddListOfProducts()
        {
            Console.WriteLine("Enter number of products: ");
            int count = int.Parse(Console.ReadLine());
            if (count > 0)
            {
                products = new Product[count];
                for (int i = 0; i < count; ++i)
                {
                    products[i] = new Product();
                    Console.WriteLine("Enter name of product: ");
                    products[i].Name = Console.ReadLine();
                    Console.WriteLine("Enter price of product: ");
                    products[i].Price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter weight of product: ");
                    products[i].Weight = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Incorrect input of number of products");
            }
        }
        
        public string Print()
        {
            string information = "Information about products in storage:\n";
            for (int i = 0; i < products.Length; ++i)
            {
                information += products[i].ToString() + "\n";
            }
            return information;
        }
        public void SearchForMeatProducts(out Meat[] meat)
        {
            int countOfMeatProducts = 0;
            Meat meatType = new Meat();
            for (int i = 0; i < products.Length; ++i)
            {
                if (products[i].GetType() == meatType.GetType())
                {
                    ++countOfMeatProducts;
                }
            }
            meat = new Meat[countOfMeatProducts];
            for (int i = 0, j = 0; i < products.Length; ++i)
            {
                if (products[i].GetType() == meatType.GetType())
                {
                    meat[j] = new Meat();
                    meat[j] = (Meat)products[i].Copy();
                    ++j;
                }
            }
        }

        public void ChangePrice(int percentage)
        {
            for (int i = 0; i < products.Length; ++i)
            {
                products[i].ChangePrice(percentage);
            }
        }
        public Product this[int i]
        {
            get { return products[i]; }
            set { products[i] = value; }
        }

    }
}
