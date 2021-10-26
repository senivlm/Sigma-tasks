using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task8_3
{
    class TextReader
    {ви не враховуєте повністю умову задачі
        private string[] tapes;
        private string[] sentences;

        public string[] Sentences
        {
            get { return sentences; }
        }
        public string this [int i]
        {
            get 
            {
                try
                {
                    if (i < 0 || i >= sentences.Length)
                        throw new ArgumentException("Incorrect index of access to tapes");
                    return sentences[i];
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return sentences[i];
            }
            set
            {
                try
                {
                    if (i < 0 || i >= sentences.Length)
                        throw new ArgumentException("Incorrect index of access to tapes");
                    sentences[i] = value;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public TextReader()
        {
            tapes = null;
        }

        public void ReadFromFile(string path)
        {
            try
            {
                if (path == "" || path == null)
                    throw new ArgumentException("Incorrect name of file");
                if (!File.Exists(path))
                    throw new FileNotFoundException("File with this name is not found");
                StreamReader file = new StreamReader(path);
                string text = file.ReadToEnd();
                if (text == "")
                    throw new ArgumentException("File is empty");
                tapes = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateSentencesFromTapes()
        {
            int dotsCount = 0;
            for (int i = 0; i < tapes.Length; ++i)
            {
                for (int j = 0; j < tapes[i].Length; ++j)
                {
                    if (tapes[i][j] == '.')
                        ++dotsCount;
                }
            }
            sentences = new string[dotsCount];
            for (int i = 0, j = 0; i < tapes.Length; ++i)
            {
                for (int  u = 0; u < tapes[i].Length; ++u)
                {
                    if (tapes[i][u] != '.')
                    { При такому варіанті string дуже затратний. Краще використовувати StringBuilder.
                        sentences[j] += tapes[i][u];
                    }
                    else
                    {
                        sentences[j] += tapes[i][u];
                        ++j;
                    }
                }
            }
        }

        public string FindSentenceWithGreatNesting()
        {
            string result = "";
            try
            {
                int openBrackets = 0, closeBrackets = 0, maxBracketsNumber = 0, indexMaxNestingSentence = 0;
                for (int i = 0; i < sentences.Length; ++i)
                {
                    openBrackets = 0;
                    closeBrackets = 0;
                    for (int j = 0; j < sentences[i].Length; ++j)
                    {
                        if (sentences[i][j] == '(')
                            ++openBrackets;
                        else if (sentences[i][j] == ')')
                            ++closeBrackets;
                    }
                    if (openBrackets != closeBrackets)
                        throw new ArgumentException($"Different number of open and close brackets in sentence: {sentences[i]}");
                    else
                    {
                        if (openBrackets > maxBracketsNumber)
                        {
                            maxBracketsNumber = openBrackets;
                            indexMaxNestingSentence = i;
                        }
                    }
                }
                return sentences[indexMaxNestingSentence];
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public void SortSentencesByLength()
        {
            List<string> sortedSentences = new List<string>();
            for (int i = 0; i < sentences.Length; ++i)
            {
                sortedSentences.Add(sentences[i]);
            }
            sortedSentences.Sort((firstSentence, secondSentence) => firstSentence.Length.CompareTo(secondSentence.Length));
            for (int i = 0; i < sentences.Length; ++i)
            {
                sentences[i] = sortedSentences[i];
            }
        }
    }
}
