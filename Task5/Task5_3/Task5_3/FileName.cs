using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_3
{
    class FileName
    {
        private string fileNameWithoutExtension;
        public string FileNameWithoutExtension
        {
            get { return fileNameWithoutExtension; }
            set 
            {
                try
                {
                    if (value == "")
                        throw new ArgumentException("Name of file without extension is empty");
                    fileNameWithoutExtension = value;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string nameRootFolder;
        public string NameRootFolder
        {
            get { return nameRootFolder; }
            set
            {
                try
                {
                    if (value == "")
                        throw new ArgumentException("Name of root folder is empty");
                    nameRootFolder = value;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public FileName()
        {
            fileNameWithoutExtension = null;
            nameRootFolder = null;
        }

        public FileName(string path)
        {
            try
            {
                string[] sentences = path.Split(" \\ ");
                for (int i = 0; i < sentences.Length; ++i)
                {
                    if (sentences[i].Trim() == string.Empty)
                        throw new ArgumentException("File path has empty part");
                }
                if (sentences.Length <= 2)
                    throw new Exception("Incorrect file path");

                int dotsCount = 0;
                int fileNameIndex = sentences.Length - 1;
                int spaceCount = 0;
                for (int i = 0; i < sentences[fileNameIndex].Length; ++i)
                {
                    if (sentences[fileNameIndex][i] == '.')
                        ++dotsCount;
                }
                if (dotsCount == 0)
                    throw new ArgumentException("File has not extension");
                else if (dotsCount > 1)
                {
                    string nameOfFile = "";
                    for (int i = 0; i < sentences[fileNameIndex].Length; ++i)
                    {
                        if ((sentences[fileNameIndex][i] == '.') && (dotsCount == 1))
                            break;
                        else
                        {
                            if (sentences[fileNameIndex][i] == '.')
                            {
                                --dotsCount;
                            }
                            nameOfFile += sentences[fileNameIndex][i];
                        }
                    }
                    FileNameWithoutExtension = nameOfFile;
                }
                else if (dotsCount == 1)
                {
                    string[] parts = sentences[fileNameIndex].Split('.', StringSplitOptions.RemoveEmptyEntries);
                    if (parts[0] == "" || (parts.Length == 1))
                        throw new Exception("File has incorrect name");
                    for (int i = 0; i < parts[0].Length; ++i)
                    {
                        if (parts[0][i] == ' ')
                            ++spaceCount;
                    }
                    if (spaceCount == parts[0].Length)
                        throw new Exception("File name consists only of spaces");
                    FileNameWithoutExtension = parts[0];
                }

                int rootFolderIndex = sentences.Length - 2;
                spaceCount = 0;
                if (sentences[rootFolderIndex] == "")
                    throw new Exception("Name of root folder is empty");
                for (int i = 0; i < sentences[rootFolderIndex].Length; ++i)
                {
                    if (sentences[rootFolderIndex][i] == ' ')
                        ++spaceCount;
                }
                if (spaceCount == sentences[rootFolderIndex].Length)
                    throw new Exception("Name of root folder consists only of spaces");
                NameRootFolder = sentences[rootFolderIndex];
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetFileName()
        {
            return FileNameWithoutExtension;
        }
        public string GetRootFolderName()
        {
            return NameRootFolder;
        }
        public string GetFullInfo()
        {
            return "File name without extension: " + FileNameWithoutExtension + "\nRoot folder name: " + NameRootFolder;
        }
    }
}
