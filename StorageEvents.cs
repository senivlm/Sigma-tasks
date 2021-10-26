using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task9
{
    class StorageEvents
    {
        public static void LogIncorrectDataInFile(string message, string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File is not found");
                StreamWriter file = new StreamWriter(path, append: true);
                string line = DateTime.Now + " " + message;
                file.WriteLine(line);
                file.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static Product CorrectProductType()
        {
            string type = "";
            while (true)
            {
                Console.WriteLine("Enter type of product:");
                type = Console.ReadLine();
                if (type == "Product")
                {
                    return new Product();
                }
                else if (type == "Meat")
                {
                    return new Meat();
                }
                else if (type == "Dairy_products")
                {
                    return new Dairy_products();
                }
            }
        }
        private static void CorrectProductName(Product product)
        {
            string name = "";
            while (true)
            {
                Console.WriteLine("Enter name of product:");
                name = Console.ReadLine();
                if (name != "")
                {
                    product.Name = name;
                    break;
                }
            }
        }
        
        private static void CorrectProductPrice(Product product)
        {
            string priceStr = "";
            while (true)
            {
                Console.WriteLine("Enter price of product:");
                priceStr = Console.ReadLine();
                if (double.TryParse(priceStr, out double price) && price > 0)
                {
                    product.Price = price;
                    break;
                }
            }
        }

        private static void CorrectProductWeight(Product product)
        {
            string weightStr = "";
            while (true)
            {
                Console.WriteLine("Enter weight of product:");
                weightStr = Console.ReadLine();
                if (double.TryParse(weightStr, out double weight) && weight > 0)
                {
                    product.Weight = weight;
                    break;
                }
            }
        }

        private static void CorrectProductExpirationDate(Product product)
        {
            string expirationDateStr = "";
            while (true)
            {
                Console.WriteLine("Enter expiration date of product:");
                expirationDateStr = Console.ReadLine();
                if (int.TryParse(expirationDateStr, out int expirationDate) && expirationDate > 0)
                {
                    product.ExpirationDate = expirationDate;
                    break;
                }
            }
        }

        private static void CorrectProductCreationDate(Product product)
        {
            string creationDateStr = "";
            string[] values;
            while (true)
            {
                Console.WriteLine("Enter creation date of product");
                creationDateStr = Console.ReadLine();
                values = creationDateStr.Split('.');
                if (values.Length == 3)
                {
                    if (int.TryParse(values[0], out int days) && int.TryParse(values[1], out int months) && int.TryParse(values[2], out int years))
                    {
                        if (months == 4 || months == 6 || months == 9 || months == 11)
                        {
                            if (days > 0 && days <= 30)
                            {
                                if (years > 1900 && years <= 2021)
                                {
                                    product.CreationDate = creationDateStr;
                                    break;
                                }
                            }
                        }
                        else if (months == 2)
                        {
                            if (DateTime.IsLeapYear(years))
                            {
                                if (days > 0 && days <= 29)
                                {
                                    if (years > 1900 && years <= 2021)
                                    {
                                        product.CreationDate = creationDateStr;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (days > 0 && days <= 28)
                                {
                                    if (years > 1900 && years <= 2021)
                                    {
                                        product.CreationDate = creationDateStr;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (months == 1 || months == 3 || months == 5 || months == 7 || months == 8 || months == 10 || months == 12)
                        {
                            if (days > 0 && days <= 31)
                            {
                                if (years > 1900 && years <= 2021)
                                {
                                    product.CreationDate = creationDateStr;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void CorrectCategoryOfMeat(Product product)
        {
            string meatCategoryStr = "";
            Meat meat = product as Meat;
            bool correctCategory = false;
            while (true)
            {
                Console.WriteLine("Enter category of meat:");
                meatCategoryStr = Console.ReadLine();
                switch (meatCategoryStr)
                {
                    case "Highest Grade":
                        meat.CategoryOfMeat = Category.HighestGrade;
                        correctCategory = true;
                        break;
                    case "First Sort":
                        meat.CategoryOfMeat = Category.FirstSort;
                        correctCategory = true;
                        break;
                    case "Second Sort":
                        meat.CategoryOfMeat = Category.SecondSort;
                        correctCategory = true;
                        break;
                }
                if (correctCategory == true)
                {
                    product = meat;
                    break;
                }
            }
        }

        private static void CorrectKindOfMeat(Product product)
        {
            string kindOfMeatStr = "";
            Meat meat = product as Meat;
            bool correctKind = false;
            while (true)
            {
                Console.WriteLine("Enter kind of meat:");
                kindOfMeatStr = Console.ReadLine();
                switch (kindOfMeatStr)
                {
                    case "Mutton":
                        meat.KindOfMeat = Kind.Mutton;
                        correctKind = true;
                        break;
                    case "Veal":
                        meat.KindOfMeat = Kind.Veal;
                        correctKind = true;
                        break;
                    case "Pork":
                        meat.KindOfMeat = Kind.Pork;
                        correctKind = true;
                        break;
                    case "Chicken":
                        meat.KindOfMeat = Kind.Chicken;
                        correctKind = true;
                        break;
                }
                if (correctKind == true)
                {
                    product = meat;
                    break;
                }
            }
        }
        public static Product CorrectProductData(Product product, string mistake)
        {
            if (mistake == "type")
            {
                product = CorrectProductType();
                return product;
            }
            else if (mistake == "name")
            {
                CorrectProductName(product);
                return product;
            }
            else if (mistake == "price")
            {
                CorrectProductPrice(product);
                return product;
            }
            else if (mistake == "weight")
            {
                CorrectProductWeight(product);
                return product;
            }
            else if (mistake == "expiration date")
            {
                CorrectProductExpirationDate(product);
                return product;
            }
            else if (mistake == "creation date")
            {
                CorrectProductCreationDate(product);
                return product;
            }
            else if (mistake == "meat category")
            {
                CorrectCategoryOfMeat(product);
                return product;
            }
            else if (mistake == "kind of meat")
            {
                CorrectKindOfMeat(product);
                return product;
            }
            return product;
        }
        public static void LogExpiredProducts(List<Product> list, string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File is not found");
                StreamWriter file = new StreamWriter(path, append: true);
                for (int i = 0; i < list.Count; ++i)
                {
                    file.WriteLine(list[i].ToString());
                }
                file.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
