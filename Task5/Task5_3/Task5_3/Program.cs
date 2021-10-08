using System;

namespace Task5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileName fileName = new FileName(@"c: \ WebServers \ home \ testsite \ www \ myfile.txt");
            Console.WriteLine(fileName.GetFullInfo());
        }
    }
}
