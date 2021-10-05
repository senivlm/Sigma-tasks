using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Storage
    {
        private Product[] products;
        public Storage()
        {
            products = null;
        }
        public Storage(Product[] products)
        {
            this.products = new Product[products.Length];
            for (int i = 0; i < products.Length; ++i)
            {
                this.products[i] = new Product();
                this.products[i] = products[i].Copy();
            }
        }
        public void FillStorage()
        {
            Console.WriteLine("Enter number of products: ");
            int count = int.Parse(Console.ReadLine());
            if (count > 0)
            {
                products = new Product[count];
                int choice = 0;
                for (int i = 0; i < count; ++i)
                {
                    Console.WriteLine("Choose type of product: 1(product), 2(meat), 3(dairy_product)");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        products[i] = new Product();
                        Console.WriteLine("Enter name of product: ");
                        products[i].Name = Console.ReadLine();
                        Console.WriteLine("Enter price of product: ");
                        products[i].Price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter weight of product: ");
                        products[i].Weight = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter expiration date of product: ");
                        products[i].ExpirationDate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter creation date of product: ");
                        products[i].CreationDate = Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (choice == 2)
                    {
                        int categoryChoice = 0;
                        int meatKindChoice = 0;
                        products[i] = new Meat();
                        Console.WriteLine("Enter name of meat: ");
                        products[i].Name = Console.ReadLine();
                        Console.WriteLine("Enter price of meat: ");
                        products[i].Price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter weight of meat: ");
                        products[i].Weight = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter expiration date of meat: ");
                        products[i].ExpirationDate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter creation date of meat: ");
                        products[i].CreationDate = Console.ReadLine();
                        Console.WriteLine("Enter category of meat: 1 (Highest Grade), 2 (First Sort), 3 (Second Sort)");
                        categoryChoice = int.Parse(Console.ReadLine());
                        switch (categoryChoice)
                        {
                            case 1:
                                (products[i] as Meat).CategoryOfMeat = Category.HighestGrade;
                                break;
                            case 2:
                                (products[i] as Meat).CategoryOfMeat = Category.FirstSort;
                                break;
                            case 3:
                                (products[i] as Meat).CategoryOfMeat = Category.SecondSort;
                                break;
                        }
                        Console.WriteLine("Enter kind of meat: 1 (Mutton), 2 (Veal), 3 (Pork), 4 (Chicken)");
                        meatKindChoice = int.Parse(Console.ReadLine());
                        switch (meatKindChoice)
                        {
                            case 1:
                                (products[i] as Meat).KindOfMeat = Kind.Mutton;
                                break;
                            case 2:
                                (products[i] as Meat).KindOfMeat = Kind.Veal;
                                break;
                            case 3:
                                (products[i] as Meat).KindOfMeat = Kind.Pork;
                                break;
                            case 4:
                                (products[i] as Meat).KindOfMeat = Kind.Chicken;
                                break;
                        }
                        

                        Console.WriteLine();
                    }
                    else if (choice == 3)
                    {
                        products[i] = new Dairy_products();
                        Console.WriteLine("Enter name of dairy_product: ");
                        products[i].Name = Console.ReadLine();
                        Console.WriteLine("Enter price of dairy_product: ");
                        products[i].Price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter weight of dairy_product: ");
                        products[i].Weight = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter expiration date of dairy_product: ");
                        products[i].ExpirationDate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter creation date of dairy_product: ");
                        products[i].CreationDate = Console.ReadLine();
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect input of number of products");
            }
        }

        public override string ToString()
        {
            string information = "Information about products in storage:\n";
            for (int i = 0; i < products.Length; ++i)
            {
                information += products[i].ToString() + "\n";
            }
            return information;
        }
        public void SearchForMeatProducts(out Meat[] meat)
        {
            int countOfMeatProducts = 0;
            Meat meatType = new Meat();
            for (int i = 0; i < products.Length; ++i)
            {
                if (products[i].GetType() == meatType.GetType())
                {
                    ++countOfMeatProducts;
                }
            }
            meat = new Meat[countOfMeatProducts];
            for (int i = 0, j = 0; i < products.Length; ++i)
            {
                if (products[i].GetType() == meatType.GetType())
                {
                    meat[j] = new Meat();
                    meat[j] = (Meat)products[i].Copy();
                    ++j;
                }
            }
        }

        public void ChangePrice(int percentage)
        {
            for (int i = 0; i < products.Length; ++i)
            {
                products[i].ChangePrice(percentage);
            }
        }
        public Product this[int i]
        {
            get { return products[i]; }
            set { products[i] = value; }
        }

        public void ExcludeDairyProducts(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new Exception("File does not exist");
                }
                StreamWriter file = new StreamWriter(path);

                Product[] productsArray = new Product[products.Length];
                for (int i = 0; i < products.Length; ++i)
                {
                    productsArray[i] = products[i].Copy();
                }
                
                DateTime date2 = DateTime.Now;
                int[] indexFreshProducts = new int[products.Length];
                int sizeFreshProducts = 0;
                for (int i = 0; i < products.Length; ++i)
                {
                    if ((products[i] is Dairy_products))
                    {
                        DateTime date1 = DateTime.Parse(products[i].CreationDate);
                        date1 = date1.AddDays(Convert.ToDouble(products[i].ExpirationDate));
                        if ((date1.CompareTo(date2)) < 0)
                        {
                            file.WriteLine(products[i].ToString());
                        }
                        else
                        {
                            indexFreshProducts[i] = 1;
                            ++sizeFreshProducts;
                        }
                    }
                    else
                    {
                        indexFreshProducts[i] = 1;
                        ++sizeFreshProducts;
                    }
                }
                products = new Product[sizeFreshProducts];
                for (int i = 0, j = 0; i < indexFreshProducts.Length; ++i)
                {
                    if (indexFreshProducts[i] == 1)
                    {
                        products[j] = productsArray[i].Copy();
                        ++j;
                    }
                }

                file.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void ReadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new Exception("File does not exist");
                }
                StreamReader file = new StreamReader(path);
                string line = file.ReadLine();
                if (!int.TryParse(line, out int productNumber))
                    throw new FormatException("Incorrect line of number of products in file");
                if (productNumber <= 0)
                    throw new IndexOutOfRangeException("Incorrect number of products");
                products = new Product[productNumber];
                for (int i = 0; i < productNumber; ++i)
                {
                    string[] split = file.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length != 6 && split.Length != 8)
                        throw new ArgumentOutOfRangeException("Incorrect number of values in tape in file");
                    if (split[0] == "Product")
                    {
                        products[i] = new Product();
                        products[i].Parse(split[1] + " " + split[2] + " " + split[3] + " " + split[4] + " " + split[5]);
                    }
                    else if (split[0] == "Meat")
                    {
                        products[i] = new Meat();
                        products[i].Parse(split[1] + " " + split[2] + " " + split[3] + " " + split[4] + " " + split[5] + " " + split[6] + " " + split[7]);
                    }
                    else if (split[0] == "Dairy_products")
                    {
                        products[i] = new Dairy_products();
                        products[i].Parse(split[1] + " " + split[2] + " " + split[3] + " " + split[4] + " " + split[5]);
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
