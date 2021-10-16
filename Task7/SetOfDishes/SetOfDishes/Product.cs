using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SetOfDishes
{
    class Product :IComparable<Product>
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
            try
            {
                this.Name = name;
                this.Price = price;
                this.Weight = weight;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Empty name of product");
                if (value.Length <= 1)
                    throw new ArgumentException("Incorrect length of name");
                name = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (!double.TryParse(Convert.ToString(value), out double productPrice))
                    throw new FormatException("Incorrect format of product price");
                if (value < 0)
                    throw new ArgumentException("Incorrect price of product");
                price = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (!double.TryParse(Convert.ToString(value), out double productWeight))
                    throw new FormatException("Incorrect format of product weight");
                if (value < 0)
                    throw new ArgumentException("Incorrect weight of product");
                weight = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var other = (Product)obj;
            return (other.Name == this.Name);
        }
        public override int GetHashCode()
        {
            return (int)Price ^ (int)Weight;
        }
        public override string ToString()
        {
            return $"{Name} {Weight} {Price}";
        }
        public Product Copy()
        {
            return (Product)this.MemberwiseClone();
        }

        public int CompareTo(Product other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
