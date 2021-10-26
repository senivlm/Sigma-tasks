using System;
using System.Collections.Generic;
using System.Text;

namespace Task9
{
    class Dairy_products : Product
    {
        public Dairy_products() : base()
        {
        }
        public Dairy_products(string name, double price, double weight, int expirationDate, string creationDate) : base(name, price, weight, expirationDate, creationDate)
        {
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
            return $"Name: {Name}, price = {Price} grn, weight = {Weight}g, expiration date: {ExpirationDate} days, creation date: {CreationDate}";
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

        public override void Parse(string s)
        {
            base.Parse(s);
        }
    }
}
