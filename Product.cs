using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    class Product
    {
        private string name;
        private double price;
        private double weight;
        public Product() 
        {
            name = null;
            price = 0;
            weight = 0;
        }
        public Product(string name, double price, double weight)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
