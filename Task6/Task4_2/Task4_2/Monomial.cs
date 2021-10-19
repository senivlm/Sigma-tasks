using System;
using System.Collections.Generic;
using System.Text;

namespace Task4_2
{
    class Monomial
    {
        private double c;

        public double C
        {
            get { return c; }
            set 
            {
                try
                {
                    if (!double.TryParse(Convert.ToString(value), out double cValue))
                        throw new FormatException("Wrong format of order in monomial");
                    c = value;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private int order;

        public int Order
        {
            get { return order; }
            set 
            {
                try
                {
                    if (!int.TryParse(Convert.ToString(value), out int orderValue))
                        throw new FormatException("Wrong format of order in monomial");
                    if (value < 0)
                        throw new ArgumentException("Incorrect number of order of monomial");
                    order = value;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Monomial()
        {
            c = 0;
            order = 0;
        }

        public Monomial(double c, int order)
        {
            this.c = c;
            this.order = order;
        }

        public Monomial Copy()
        {
            return (Monomial)this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            Monomial other = (Monomial)obj;
            return (this.Order == other.Order);
        }

        public override int GetHashCode()
        {
            return (int)c ^ order;
        }
    }
}
