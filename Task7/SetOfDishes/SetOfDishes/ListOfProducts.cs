using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SetOfDishes
{
    class ListOfProducts
    {Не зрозуміли умову задачі. 
        private Product[] products;

        public Product this[int i]
        {
            get 
            {
                try
                {
                    if (i < 0 || i > products.Length)
                        throw new ArgumentException("Incorrect index of product");
                    return products[i];
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return products[i];
            }
            set 
            {
                try
                {
                    if (i < 0 || i > products.Length)
                        throw new ArgumentException("Incorrect index of products");
                    products[i] = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public ListOfProducts()
        {
            products = null;
        }

        public ListOfProducts(string menuPath, string pricePath)
        {
            try
            {
                if (menuPath == "" || menuPath == null)
                    throw new ArgumentException("Incorrect name of menu file");
                if (pricePath == "" || pricePath == null)
                    throw new ArgumentException("Incorrect name of prices file");
                if (!File.Exists(menuPath))
                    throw new FileNotFoundException("File with menu does not exist");
                if (!File.Exists(pricePath))
                    throw new FileNotFoundException("File with prices does not exist");

                StreamReader menu = new StreamReader(menuPath);
                StreamReader prices = new StreamReader(pricePath);
                string textMenu = menu.ReadToEnd();
                string textPrices = prices.ReadToEnd();
                if (textMenu == null || textMenu == "")
                    throw new ArgumentException("File with menu is empty");
                if (textPrices == null || textPrices == "")
                    throw new ArgumentException("File with prices is empty");

                string[] menuSentences = textMenu.Split("\r\n");
                string[] line;
                Dictionary<string, double> components = new Dictionary<string, double>();
                for (int i = 0; i < menuSentences.Length; ++i)
                {
                    if (menuSentences[i] != "")
                    {
                        if (!Char.IsUpper(menuSentences[i][0]))
                            throw new ArgumentException($"Line {i + 1} in file with menu must start with a capital letter");
                        line = menuSentences[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (i!=0 && (line.Length == 1))
                        {
                            if (menuSentences[i - 1] != "")
                                throw new ArgumentException("There is no indent between dishes");
                        }
                        if (line.Length > 2)
                            throw new ArgumentException($"Too many arguments in file with menu in line {i + 1}");
                        if (line.Length == 2)
                        {
                            if (!double.TryParse(line[1], out double weight))
                                throw new FormatException($"Incorrect format of weight in file with menu in line {i + 1}");
                            if (!components.ContainsKey(line[0]))
                            {
                                components.Add(line[0], double.Parse(line[1]));
                            }
                            else
                            {
                                components[line[0]] += double.Parse(line[1]);
                            }
                        }
                    }
                }
                products = new Product[components.Count];
                string[] pricesSentences = textPrices.Split("\r\n");
                string[] linePrices;
                int index = 0;
                double productPrice = 0;
                foreach (KeyValuePair<string, double> item in components)
                {
                    if (components.Count != pricesSentences.Length)
                        throw new ArgumentException("Incorrect number of products if file with prices");
                    if (pricesSentences[index] == "")
                        throw new ArgumentException($"Empty line {index + 1} in file with prices");
                    linePrices = pricesSentences[index].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (linePrices.Length != 2)
                        throw new ArgumentException($"Incorrect number of arguments in file with prices in line {index + 1}");
                    if (!double.TryParse(linePrices[1], out double price))
                        throw new FormatException($"Incorrect format of price in file with prices in line {index + 1}");
                    if (!components.ContainsKey(linePrices[0]))
                        throw new ArgumentException($"File with prices has other component in line {index + 1}");
                    if (components.ContainsKey(linePrices[0]))
                    {
                        productPrice = components[linePrices[0]] * (double.Parse(linePrices[1]));
                    }
                    products[index] = new Product(linePrices[0], Math.Round(productPrice, 2), Math.Round(components[linePrices[0]], 2));
                    ++index;
                }
                index = 0;
                List<Product> sortedProducts = new List<Product>();
                for (int i = 0; i < products.Length; ++i)
                {
                    sortedProducts.Add(products[i]);
                }
                sortedProducts.Sort((product1, product2) => product1.CompareTo(product2));
                foreach (Product item in sortedProducts)
                {
                    products[index] = item;
                    ++index;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetListOfProducts()
        {
            string result = "";
            for (int i = 0; i < products.Length; ++i)
            {
                result += products[i].ToString() + "\n";
            }
            return result;
        }
    }
}
