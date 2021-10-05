using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    enum Category { HighestGrade, FirstSort, SecondSort };
    enum Kind { Mutton, Veal, Pork, Chicken };
    class Meat : Product
    {
        private Category categoryOfMeat;
        public Category CategoryOfMeat
        {
            get { return categoryOfMeat; }
            set 
            {
                categoryOfMeat = value; 
            }
        }

        private Kind kindOfMeat;
        public Kind KindOfMeat
        {
            get { return kindOfMeat; }
            set 
            {
                string kindCategoryString = Convert.ToString(value);
                if (!Enum.TryParse(kindCategoryString, true, out Kind meatKind))
                    throw new Exception("Incorrect kind of meat");
                kindOfMeat = value; 
            }
        }

        public Meat() : base()
        {
        }
        public Meat(string name, double price, double weight, Kind kindOfMeat, Category categoryOfMeat, int expirationDate, string creationDate) : base(name, price, weight, expirationDate, creationDate) 
        {
            this.kindOfMeat = kindOfMeat;
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
            return $"Name: {Name}, price = {Price} grn, weight = {Weight}g, expiration date: {ExpirationDate}, creation date: {CreationDate}, category: {CategoryOfMeat}, kind of meat: {KindOfMeat}";
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

        public override void Parse(string s)
        {
            string[] split = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (split.Length != 7)
                    throw new Exception("Incorrect number of values in tape");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Name = split[0];
                Price = double.Parse(split[1]);
                Weight = double.Parse(split[2]);
                ExpirationDate = int.Parse(split[3]);
                CreationDate = split[4];
                if (!Enum.TryParse(split[5], true, out Category meatCategory))
                    throw new Exception("Incorrect category of meat");
                switch (split[5])
                {
                    case "HighestGrade":
                        CategoryOfMeat = Category.HighestGrade;
                        break;
                    case "FirstSort":
                        CategoryOfMeat = Category.FirstSort;
                        break;
                    case "SecondSort":
                        CategoryOfMeat = Category.SecondSort;
                        break;
                }
                if (!Enum.TryParse(split[6], true, out Kind meatKind))
                    throw new Exception("Incorrect kind of meat");
                switch (split[6])
                {
                    case "Mutton":
                        KindOfMeat = Kind.Mutton;
                        break;
                    case "Veal":
                        KindOfMeat = Kind.Veal;
                        break;
                    case "Pork":
                        KindOfMeat = Kind.Pork;
                        break;
                    case "Chicken":
                        KindOfMeat = Kind.Chicken;
                        break;
                }

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
