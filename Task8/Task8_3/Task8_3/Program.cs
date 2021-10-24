using System;

namespace Task8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            TextReader textReader = new TextReader();
            textReader.ReadFromFile(@"C:\Users\vvlad\Desktop\Sigma\Task8\Task8_3\Task8_3\input.txt");
            textReader.CreateSentencesFromTapes();
            Console.WriteLine(textReader.FindSentenceWithGreatNesting());
            Console.WriteLine();
            textReader.SortSentencesByLength();
            for (int i = 0; i < textReader.Sentences.Length; ++i)
            {
                Console.WriteLine(textReader[i]);
            }
        }
    }
}
