using System;

namespace Task4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial polynomial1 = new Polynomial();
            polynomial1.Parse("7+8*x^1+10*x^2+3*x^3");
            Polynomial polynomial2 = new Polynomial();
            polynomial2.Parse("5+10*x^1+2*x^2");
            Console.WriteLine(polynomial1.ToString());
            Console.WriteLine(polynomial2.ToString());
            Polynomial polynomial3 = polynomial1 + polynomial2;
            Console.WriteLine(polynomial3.ToString());
            double value = 7;
            Polynomial polynomial4 = value;
            Console.WriteLine(polynomial4.ToString());
        }
    }
}
