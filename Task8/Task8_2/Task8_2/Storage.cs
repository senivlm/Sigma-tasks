using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task8_2
{
    class Storage
    {
        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
        }
        public Storage()
        {
            products = new List<Product>();
        }
        public Storage(List<Product> list)
        {
            products = new List<Product>();
            for (int i = 0; i < list.Count; ++i)
            {
                products.Add(list[i]);
            }
        }

        public override string ToString()
        {
            string information = "Information about products in storage:\n";
            for (int i = 0; i < products.Count; ++i)
            {
                information += products[i].ToString() + "\n";
            }
            return information;
        }

        public Product this[int i]
        {
            get { return products[i]; }
            set { products[i] = value; }
        }
    }
}
