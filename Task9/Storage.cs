using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task9
{
    class Storage
    {
        public delegate void LogIncorrectInput(string message, string path);
        public delegate Product CorrectInput(Product product, string mistake);
        public delegate void LogExpiredProducts(List<Product> list, string path);

        public event LogIncorrectInput OnLogIncorrectInfoToFile;
        public event CorrectInput OnCorrectDataProduct;
        public event LogExpiredProducts OnLogExpiredProducts;
        private List<Product> products;
        public Storage()
        {
            products = new List<Product>();
        }
        public Storage(List<Product> products)
        {
            this.products = products;
        }

        private void FillProduct(Product product)
        {
            Console.WriteLine("Enter name of product: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter price of product: ");
            product.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter weight of product: ");
            product.Weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter expiration date of product: ");
            product.ExpirationDate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter creation date of product: ");
            product.CreationDate = Console.ReadLine();
        }
        
        private void FillCategoryAndKindOfMeat(Product product)
        {
            int categoryChoice = 0;
            int meatKindChoice = 0;
            Console.WriteLine("Enter category of meat: 1 (Highest Grade), 2 (First Sort), 3 (Second Sort)");
            categoryChoice = int.Parse(Console.ReadLine());
            switch (categoryChoice)
            {
                case 1:
                    (product as Meat).CategoryOfMeat = Category.HighestGrade;
                    break;
                case 2:
                    (product as Meat).CategoryOfMeat = Category.FirstSort;
                    break;
                case 3:
                    (product as Meat).CategoryOfMeat = Category.SecondSort;
                    break;
            }
            Console.WriteLine("Enter kind of meat: 1 (Mutton), 2 (Veal), 3 (Pork), 4 (Chicken)");
            meatKindChoice = int.Parse(Console.ReadLine());
            switch (meatKindChoice)
            {
                case 1:
                    (product as Meat).KindOfMeat = Kind.Mutton;
                    break;
                case 2:
                    (product as Meat).KindOfMeat = Kind.Veal;
                    break;
                case 3:
                    (product as Meat).KindOfMeat = Kind.Pork;
                    break;
                case 4:
                    (product as Meat).KindOfMeat = Kind.Chicken;
                    break;
            }
        }
        public void FillStorage()
        {
            Console.WriteLine("Enter number of products: ");
            int count = int.Parse(Console.ReadLine());
            if (count > 0)
            {
                int choice = 0;
                for (int i = 0; i < count; ++i)
                {
                    Console.WriteLine("Choose type of product: 1(product), 2(meat), 3(dairy_product)");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        products.Add(new Product());
                        FillProduct(products[i]);
                        Console.WriteLine();
                    }
                    else if (choice == 2)
                    {
                        products.Add(new Meat());
                        FillProduct(products[i]);
                        FillCategoryAndKindOfMeat(products[i]);
                        Console.WriteLine();
                    }
                    else if (choice == 3)
                    {
                        products.Add(new Dairy_products());
                        FillProduct(products[i]);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect input of number of products");
            }
        }
        public void SearchForMeatProducts(out Meat[] meat)
        {
            int countOfMeatProducts = 0;
            Meat meatType = new Meat();
            for (int i = 0; i < products.Count; ++i)
            {
                if (products[i] is Meat)
                {
                    ++countOfMeatProducts;
                }
            }
            meat = new Meat[countOfMeatProducts];
            for (int i = 0, j = 0; i < products.Count; ++i)
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
            for (int i = 0; i < products.Count; ++i)
            {
                products[i].ChangePrice(percentage);
            }
        }
        public Product this[int i]
        {
            get 
            {
                try
                {
                    if (i < 0 || i >= products.Count)
                        throw new ArgumentException("Index out of range");
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
                    if (i < 0 || i >= products.Count)
                        throw new ArgumentException("Index out of range");
                    products[i] = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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

                Product[] productsArray = new Product[products.Count];
                for (int i = 0; i < products.Count; ++i)
                {
                    productsArray[i] = products[i].Copy();
                }

                DateTime date2 = DateTime.Now;
                int[] indexFreshProducts = new int[products.Count];
                int sizeFreshProducts = 0;
                for (int i = 0; i < products.Count; ++i)
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
                products = null;
                for (int i = 0, j = 0; i < indexFreshProducts.Length; ++i)
                {
                    if (indexFreshProducts[i] == 1)
                    {
                        products.Add(new Product());
                        products[j] = productsArray[i].Copy();
                        ++j;
                    }
                }

                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ReadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File is not found");

                StreamReader file = new StreamReader(path);

                string text = file.ReadToEnd();
                if (text == "" || text == null)
                    throw new ArgumentException("File is empty");

                string[] lines = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lines.Length; ++i)
                {
                    string[] split = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length != 6 && split.Length != 8)
                        throw new ArgumentException($"Incorrect number of values in line {lines[i]}");
                    if (split[0] == "Product")
                    {
                        products.Add(new Product());
                        products[i].Parse(split[1] + " " + split[2] + " " + split[3] + " " + split[4] + " " + split[5]);
                    }
                    else if (split[0] == "Meat")
                    {
                        products.Add(new Meat());
                        products[i].Parse(split[1] + " " + split[2] + " " + split[3] + " " + split[4] + " " + split[5] + " " + split[6] + " " + split[7]);
                    }
                    else if (split[0] == "Dairy_products")
                    {
                        products.Add(new Dairy_products());
                        products[i].Parse(split[1] + " " + split[2] + " " + split[3] + " " + split[4] + " " + split[5]);
                    }
                    else
                    {
                        throw new ArgumentException($"Incorrect type of product in line {lines[i]}");
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
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

        private Product EnterType(Product product)
        {
            string type = "";
            Console.WriteLine("Enter type of product:");
            type = Console.ReadLine();
            switch (type)
            {
                case "Product":
                    return new Product();
                case "Meat":
                    return new Meat();
                case "Dairy_products":
                    return new Dairy_products();
                default:
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect type of product: {type}", "./output.txt");
                    return OnCorrectDataProduct?.Invoke(product, "type");
            }
        }

        private void EnterName(Product product)
        {
            Console.WriteLine("Enter name of product:");
            string nameStr = "";
            nameStr = Console.ReadLine();
            if (nameStr == "")
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect name of product: {product.Name}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "name");
            }
            else
            {
                product.Name = nameStr;
            }
        }

        private void EnterPrice(Product product)
        {
            Console.WriteLine("Enter price of product:");
            string priceStr = Console.ReadLine();
            if (!double.TryParse(priceStr, out double price))
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect format of product price: {priceStr}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "price");
            }
            else if (price <= 0)
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect product price: {priceStr}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "price");
            }
            else
            {
                product.Price = price;
            }
        }

        private void EnterWeight(Product product)
        {
            Console.WriteLine("Enter weight of product:");
            string weightStr = Console.ReadLine();
            if (!double.TryParse(weightStr, out double weight))
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect format of product weight: {weightStr}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "weight");
            }
            else if (weight <= 0)
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect product weight: {weightStr}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "weight");
            }
            else
            {
                product.Weight = weight;
            }
        }

        private void EnterExpirationDate(Product product)
        {
            Console.WriteLine("Enter expiration date of product:");
            string expirationDateStr = Console.ReadLine();
            if (!int.TryParse(expirationDateStr, out int expirationDate))
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect format of expiration date of product: {expirationDateStr}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "expiration date");
            }
            else if (expirationDate <= 0)
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect expiration date of product: {expirationDateStr}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "expiration date");
            }
            else
            {
                product.ExpirationDate = expirationDate;
            }
        }

        private void EnterCreationDate(Product product)
        {
            Console.WriteLine("Enter creation date of product:");
            string creationDateStr = Console.ReadLine();
            string[] values = creationDateStr.Split(".");
            bool creationDateIsChanged = false;
            if (values.Length != 3)
            {
                OnLogIncorrectInfoToFile?.Invoke($"Incorrect number of values in creation date: {creationDateStr}", @"./output.txt");
                OnCorrectDataProduct?.Invoke(product, "creation date");
                creationDateIsChanged = true;
            }
            else
            {
                if (!int.TryParse(values[0], out int days) && (!creationDateIsChanged))
                {
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect format of days in creation date: {creationDateStr}", @"./output.txt");
                    OnCorrectDataProduct?.Invoke(product, "creation date");
                    creationDateIsChanged = true;
                }
                if (!int.TryParse(values[1], out int months) && (!creationDateIsChanged))
                {
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect format of months in creation date: {creationDateStr}", @"./output.txt");
                    OnCorrectDataProduct?.Invoke(product, "creation date");
                    creationDateIsChanged = true;
                }
                if (!int.TryParse(values[2], out int years) && (!creationDateIsChanged))
                {
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect format of years in creation date: {creationDateStr}", @"./output.txt");
                    OnCorrectDataProduct?.Invoke(product, "creation date");
                    creationDateIsChanged = true;
                }

                switch (months)
                {
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if ((int.Parse(values[0]) < 0 || int.Parse(values[0]) > 30) && (!creationDateIsChanged))
                        {
                            OnLogIncorrectInfoToFile?.Invoke($"Incorrect number of days in creation date: {creationDateStr}", @"./output.txt");
                            OnCorrectDataProduct?.Invoke(product, "creation date");
                            creationDateIsChanged = true;
                        }
                        break;
                    case 2:
                        if (DateTime.IsLeapYear(years))
                            if ((int.Parse(values[0]) < 0 || int.Parse(values[0]) > 29) && (!creationDateIsChanged))
                            {
                                OnLogIncorrectInfoToFile?.Invoke($"Incorrect number of days in creation date: {creationDateStr}", @"./output.txt");
                                OnCorrectDataProduct?.Invoke(product, "creation date");
                                creationDateIsChanged = true;
                            }
                            else if ((int.Parse(values[0]) < 0 || int.Parse(values[0]) > 28) && (!creationDateIsChanged))
                            {
                                OnLogIncorrectInfoToFile?.Invoke($"Incorrect number of days in creation date: {creationDateStr}", @"./output.txt");
                                OnCorrectDataProduct?.Invoke(product, "creation date");
                                creationDateIsChanged = true;
                            }
                        break;
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if ((int.Parse(values[0]) < 0 || int.Parse(values[0]) > 31) && (!creationDateIsChanged))
                        {
                            OnLogIncorrectInfoToFile?.Invoke($"Incorrect number of days in creation date: {creationDateStr}", @"./output.txt");
                            OnCorrectDataProduct?.Invoke(product, "creation date");
                            creationDateIsChanged = true;
                        }
                        break;
                }
                if (((months <= 0) || (months > 12)) && (!creationDateIsChanged))
                {
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect number of months in creation date: {creationDateStr}", @"./output.txt");
                    OnCorrectDataProduct?.Invoke(product, "creation date");
                    creationDateIsChanged = true;
                }
                if (((years < 1900) || (years > 2021)) && (!creationDateIsChanged))
                {
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect number of years in creation date: {creationDateStr}", @"./output.txt");
                    OnCorrectDataProduct?.Invoke(product, "creation date");
                    creationDateIsChanged = true;
                }
                if (!creationDateIsChanged)
                {
                    product.CreationDate = values[0] + "." + values[1] + "." + values[2];
                }
            }
        }

        private void EnterCategoryOfMeat(Product product)
        {
            Meat meatProduct = product as Meat;
            Console.WriteLine("Enter category of meat:");
            string categoryOfMeatStr = Console.ReadLine();
            switch (categoryOfMeatStr)
            {
                case "Highest Grade":
                    meatProduct.CategoryOfMeat = Category.HighestGrade;
                    break;
                case "First Sort":
                    meatProduct.CategoryOfMeat = Category.FirstSort;
                    break;
                case "Second Sort":
                    meatProduct.CategoryOfMeat = Category.SecondSort;
                    break;
                default:
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect meat category: {categoryOfMeatStr}", @"./output.txt");
                    OnCorrectDataProduct?.Invoke(meatProduct, "meat category");
                    break;
            }
            product = meatProduct;
        }

        private void EnterKindOfMeat(Product product)
        {
            Meat meatProduct = product as Meat;
            Console.WriteLine("Enter kind of meat");
            string kindOfMeatStr = Console.ReadLine();
            switch (kindOfMeatStr)
            {
                case "Mutton":
                    meatProduct.KindOfMeat = Kind.Mutton;
                    break;
                case "Veal":
                    meatProduct.KindOfMeat = Kind.Veal;
                    break;
                case "Pork":
                    meatProduct.KindOfMeat = Kind.Pork;
                    break;
                case "Chicken":
                    meatProduct.KindOfMeat = Kind.Chicken;
                    break;
                default:
                    OnLogIncorrectInfoToFile?.Invoke($"Incorrect kind of meat: {kindOfMeatStr}", @"./output.txt");
                    OnCorrectDataProduct?.Invoke(meatProduct, "kind of meat");
                    break;
            }
            product = meatProduct;
        }

        public void AddProduct()
        {
            Product product = EnterType(new Product());
            EnterName(product);
            EnterPrice(product);
            EnterWeight(product);
            EnterExpirationDate(product);
            EnterCreationDate(product);

            if (product is Meat)
            {
                EnterCategoryOfMeat(product);
                EnterKindOfMeat(product);
                products.Add(product);
            }
            else
            {
                products.Add(product);
            }
        }

        public void ExcludeProduct(string name)
        {
            bool foundProduct = false;
            for (int i = 0; i < products.Count; ++i)
            {
                if (name == products[i].Name)
                {
                    foundProduct = true;
                    products.Remove(products[i]);
                }
            }
            if (foundProduct == false)
            {
                OnLogIncorrectInfoToFile?.Invoke($"There is no product to exclude with this name: {name}", @"./output.txt");
            }
        }

        public Product SearchProduct(string attribute)
        {
            string[] productsStr = new string[products.Count];
            int indexFoundProduct = -1;
            for (int i = 0; i < products.Count; ++i)
            {
                if (products[i] is Meat)
                {
                    Meat meat = products[i] as Meat;
                    productsStr[i] = meat.Name + " " + meat.Price + " " + meat.Weight + " " + meat.ExpirationDate + " " + meat.CreationDate
                        + " " + meat.CategoryOfMeat + " " + meat.KindOfMeat;
                }
                else
                {
                    productsStr[i] = products[i].Name + " " + products[i].Price + " " + products[i].Weight + " " + products[i].ExpirationDate + " " + products[i].CreationDate;
                }
            }
            string[] info;
            for (int i = 0; i < productsStr.Length; ++i)
            {
                info = productsStr[i].Split(' ');
                for (int j = 0; j < info.Length; ++j)
                {
                    if (attribute == info[j])
                    {
                        indexFoundProduct = i;
                    }
                }
                if (indexFoundProduct >= 0)
                {
                    break;
                }
            }
            if (indexFoundProduct >= 0)
            {
                return products[indexFoundProduct];
            }
            else
            {
                OnLogIncorrectInfoToFile?.Invoke($"No product was found for this attribute: {attribute}", @"./output.txt");
                return new Product();
            }

        }

        public override string ToString()
        {
            string information = "Information about products in storage:\n";
            DateTime now = DateTime.Now;
            DateTime expirationDate;
            List<Product> expiredProducts = new List<Product>();
            for (int i = 0; i < products.Count;)
            {
                expirationDate = DateTime.Parse(products[i].CreationDate);
                expirationDate = expirationDate.AddDays(products[i].ExpirationDate);
                if ((expirationDate.CompareTo(now)) < 0)
                {
                    expiredProducts.Add(products[i]);
                    this.ExcludeProduct(products[i].Name);
                }
                else
                {
                    information += products[i].ToString() + "\n";
                    ++i;
                }
            }
            OnLogExpiredProducts?.Invoke(expiredProducts, @"./expired products.txt");
            return information;
        }
    }
}
