using System;
using System.IO;
using System.Collections.Generic;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.ReadFromFile(@"./input.txt");
            storage.OnLogIncorrectInfoToFile += StorageEvents.LogIncorrectDataInFile;
            storage.OnCorrectDataProduct += StorageEvents.CorrectProductData;
            storage.OnLogExpiredProducts += StorageEvents.LogExpiredProducts;
            storage.AddProduct();
            storage.ExcludeProduct("Pork");
            Console.WriteLine(storage.ToString());
        }
    }
}
