using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
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

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var other = (Product)obj;
            return (other.Name == this.Name) && (other.Price == this.Price) && (other.Weight == this.Weight);
        }
        public override int GetHashCode()
        {
            return (int)Price ^ (int)Weight;
        }
        public override string ToString()
        {
            return $"Name: {Name}, price = {Price} grn, weight = {Weight}g";
        }
        public Product Copy()
        {
            return (Product)this.MemberwiseClone();
        }

        public virtual void ChangePrice(int percentage)
        {
            double standardPercentage = 1;
            standardPercentage += (double)percentage / 100;
            Price *= standardPercentage;
        }
    }

    enum Category { HighestGrade, FirstSort, SecondSort };
    enum Kind { Mutton, Veal, Pork, Chicken };
    class Meat : Product
    {
        private Category categoryOfMeat;
        public Category CategoryOfMeat
        {
            get { return categoryOfMeat; }
            set { categoryOfMeat = value; }
        }

        private Kind kindOfMeat;
        public Kind KindOfMeat
        {
            get { return kindOfMeat; }
            set { kindOfMeat = value; }
        }

        public Meat()
        {
            Name = null;
            Price = 0;
            Weight = 0;
        }
        public Meat(string name, double price, double weight, Kind kindOfMeat) : base(name,price,weight)
        {
            this.kindOfMeat = kindOfMeat;
        }
        public Meat(string name, double price, double weight, Kind kindOfMeat, Category categoryOfMeat) : this(name, price, weight, kindOfMeat)
        {
            this.categoryOfMeat = categoryOfMeat;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var other = (Meat)obj;
            return (other.Name == this.Name) && (other.Price == this.Price) && (other.Weight == this.Weight) && (other.KindOfMeat == this.KindOfMeat) && (other.CategoryOfMeat == this.CategoryOfMeat);
        }
        public override int GetHashCode()
        {
            return (int)Price ^ (int)Weight;
        }
        public override string ToString()
        {
            return $"Name: {Name}, price = {Price} grn, weight = {Weight}g, kind of meat: {KindOfMeat}, category: {CategoryOfMeat}";
        }
        public new Meat Copy()
        {
            return (Meat)this.MemberwiseClone();
        }

        public override void ChangePrice(int percentage)
        {
            double standardPercentage = 1;
            standardPercentage += (double)percentage / 100;
            switch (CategoryOfMeat)
            {
                case Category.SecondSort:
                    standardPercentage += 0.1;
                    Price *= standardPercentage;
                    break;
                case Category.FirstSort:
                    standardPercentage += 0.2;
                    Price *= standardPercentage;
                    break;
                case Category.HighestGrade:
                    standardPercentage += 0.3;
                    Price *= standardPercentage;
                    break;
            }
        }
    }

    class Dairy_products : Product
    {
        private int expirationDate;
        public int ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public Dairy_products()
        {
            Name = null;
            Price = 0;
            Weight = 0;
        }
        public Dairy_products(string name, double price, double weight, int expirationDate) : base(name, price, weight)
        {
            if (expirationDate <= 0)
            {
                Console.WriteLine("Incorrect input of expiration of product");
            }
            else
            {
                this.expirationDate = expirationDate;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var other = (Dairy_products)obj;
            return (other.Name == this.Name) && (other.Price == this.Price) && (other.Weight == this.Weight) && (other.ExpirationDate == this.ExpirationDate);
        }
        public override int GetHashCode()
        {
            return (int)Price ^ (int)Weight;
        }
        public override string ToString()
        {
            return $"Name: {Name}, price = {Price} grn, weight = {Weight}g, expiration date: {ExpirationDate} days";
        }
        public new Dairy_products Copy()
        {
            return (Dairy_products)this.MemberwiseClone();
        }

        public override void ChangePrice(int percentage)
        {
            double standardPercentage = 1;
            standardPercentage += (double)percentage / 100;
            if (ExpirationDate > 0 && ExpirationDate < 3)
            {
                standardPercentage -= 0.5;
            }
            else if (ExpirationDate >= 3 && ExpirationDate < 10)
            {
                standardPercentage -= 0.2;
            }
            else
            {
                standardPercentage += 0.1;
            }
            Price *= standardPercentage;
        }
    }
}
