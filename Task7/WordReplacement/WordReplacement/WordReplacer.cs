using System;
using System.Collections.Generic;
using System.Text;

namespace WordReplacement
{
    class WordReplacer
    {
        private Dictionary<string, string> wordsDictionary;
        public Dictionary<string, string> WordsDictionary
        {
            get { return wordsDictionary; }
        }
Хардкод!
        public WordReplacer()
        {
            wordsDictionary = new Dictionary<string, string>();
            wordsDictionary.Add("I", "boy");
            wordsDictionary.Add("go", "run");
            wordsDictionary.Add("to", "to");
            wordsDictionary.Add("school", "cinema");
        }

        public string TranslateText(string text)
        {
            string result = "";
            try
            {
                char[] separators = new char[] { ' ', '.', ',', ':', '-' };
                if (text == "" || text == null)
                    throw new ArgumentException("Input text is empty");
                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int wordsNumber = 0;
                for (int i = 0; i < text.Length;)
                {
                    if (!Char.IsLetter(text[i]))
                    {
                        result += text[i];
                        ++i;
                    }
                    else
                    {
                        if (wordsDictionary.ContainsKey(words[wordsNumber]))
                        {
                            result += wordsDictionary[words[wordsNumber]];
                            i += words[wordsNumber].Length;
                            ++wordsNumber;
                        }
                        else
                        {
                            Console.WriteLine($"There is no such word in the dictionary, write translation of this word - {words[wordsNumber]}:");
                            string word = Console.ReadLine();
                            А якщо користувач ввів enter
                                
                            for (int j = 0; j < word.Length; ++j)
                            {
                                if (!Char.IsLetter(word[j]))
                                    throw new ArgumentException("Incorrect input of word");
                            }
                            wordsDictionary.Add(words[wordsNumber], word);
                        }
                    }
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
