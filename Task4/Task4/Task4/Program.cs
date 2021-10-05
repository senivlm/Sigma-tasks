using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.ReadFromFile(@"./input.txt");
            Console.WriteLine(storage.ToString());
            storage.ExcludeDairyProducts(@"./output.txt");
        }
    }
}
