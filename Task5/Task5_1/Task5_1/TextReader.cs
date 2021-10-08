using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task5_1
{
    class TextReader
    {
        private string[] sentences;

        public string[] Sentences
        {
            get { return sentences; }
            set { sentences = value; }
        }

        public TextReader()
        {
            sentences = null;
        }

        public TextReader(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File not found");
                StreamReader file = new StreamReader(path);
                sentences = file.ReadToEnd().Split("\r\n");
                if (sentences[0] == "")
                    throw new ArgumentException("Empty file");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string ChangedText()
        {
            int sharpsCount = 0;
            string result = "";
            for (int i = 0; i < sentences.Length; ++i)
            {
                for (int j = 0; j < sentences[i].Length; ++j)
                {
                    if (sentences[i][j] == '#')
                    {
                        ++sharpsCount;
                    }
                }
            }
            try
            {
                if ((sharpsCount % 2) == 1)
                    throw new ArgumentException("Incorrect number of sharps in file");
                int leftSharps = sharpsCount / 2;
                int rightSharps = sharpsCount / 2;
                for (int i = 0, k = 0; i < sentences.Length; ++i)
                {
                    for (int j = 0; j < sentences[i].Length; ++j, ++k)
                    {
                        if (sentences[i][j] == '#')
                        {
                            if (leftSharps > 0)
                            {
                                result += '<';
                                --leftSharps;
                            }
                            else if (rightSharps > 0)
                            {
                                result += '>';
                                --rightSharps;
                            }
                        }
                        else
                        {
                            result += sentences[i][j];
                        }
                    }
                    result += "\n";
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
