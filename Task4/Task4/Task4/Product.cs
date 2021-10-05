using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Product
    {
        private string name;
        private double price;
        private double weight;
        private int expirationDate;
        private string creationDate;
        public Product()
        {
            name = null;
            price = 0;
            weight = 0;
            expirationDate = 0;
            creationDate = null;
        }
        public Product(string name, double price, double weight, int expirationDate, string creationDate)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
            this.expirationDate = expirationDate;
            this.creationDate = creationDate;
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

        public int ExpirationDate
        {
            get { return expirationDate; }
            set 
            {
                if (!int.TryParse(Convert.ToString(value), out int productExpirationDate))
                    throw new FormatException("Incorrect format of product expiration date");
                if (value < 0)
                    throw new ArgumentException("Incorrect expiration date of product");
                expirationDate = value;
            }
        }

        public string CreationDate
        {
            get { return creationDate; }
            set
            {
                string[] values = value.Split(".");
                if (values.Length != 3)
                    throw new ArgumentException("Incorrect number of values in tape of creation date");
                if (!int.TryParse(values[0], out int days) || !int.TryParse(values[1], out int months) || !int.TryParse(values[2], out int years))
                {
                    throw new FormatException("Wrong input formats of values in tape");
                }
                switch (months)
                {
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (int.Parse(values[0]) < 0 || int.Parse(values[0]) > 30)
                            throw new ArgumentException($"Wrong number of days ({days}) in month ({months}) in tape");
                        break;
                    case 2:
                        if (DateTime.IsLeapYear(years))
                            if (int.Parse(values[0]) < 0 || int.Parse(values[0]) > 29)
                                throw new ArgumentException($"Wrong nubmer of days ({days}) in month ({months}) in leap year");
                            else if (int.Parse(values[0]) < 0 || int.Parse(values[0]) > 28)
                                throw new ArgumentException($"Wrong nubmer of days ({days}) in month ({months})");
                        break;
                    default:
                        if (int.Parse(values[0]) < 0 || int.Parse(values[0]) > 31)
                            throw new ArgumentException($"Wrong number of days ({days}) in month ({months}) in tape");
                        break;
                }
                if ((int.Parse(values[1]) <= 0) || (int.Parse(values[1]) > 12))
                {
                    throw new ArgumentOutOfRangeException($"Wrong input of months ({months}) in tape");
                }
                if ((int.Parse(values[2]) < 1900) || (int.Parse(values[2]) > 2021))
                {
                    throw new ArgumentOutOfRangeException($"Wrong input of years ({years}) in tape");
                }
                creationDate = values[0] + "." + values[1] + "." + values[2];
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
            return $"Name: {Name}, price = {Price} grn, weight = {Weight}g, expiration date: {ExpirationDate} days, creation date: {CreationDate}";
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

        public virtual void Parse (string s)
        {
            string[] split = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (split.Length != 5)
                    throw new Exception("Incorrect number of values in tape");
            }
            catch(Exception ex)
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
            }
            catch(ArgumentNullException ex)
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
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
