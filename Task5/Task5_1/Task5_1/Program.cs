using System;

namespace Task5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            TextReader textReader = new TextReader("./input.txt");
            string result = textReader.ChangedText();
            Console.WriteLine(result);
        }
    }
}
