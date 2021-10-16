using System;

namespace WordReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            WordReplacer wordReplacer = new WordReplacer();
            Console.WriteLine(wordReplacer.TranslateText("I go to school. Girl runs to school"));
        }
    }
}
