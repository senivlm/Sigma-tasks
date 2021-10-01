using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounting accounting = new Accounting(@"./input.txt");
            Console.WriteLine(accounting.ToString());
            Console.WriteLine(accounting.PrintSingularFlat(3));
            Console.WriteLine(accounting.GetOwnerWithBiggestDebt());
            Console.WriteLine(accounting.GetFlatNumberWithoutUsingElectricity());
        }
    }
}
