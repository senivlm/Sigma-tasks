using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    static class GiftFormingOptions
    {
        private static int toysCount = 0;
        private static int edibleCount = 0;
        private static int wishesCount = 0;
        public static void FirstOption(ChildRequest childRequest, GiftBuilder giftBuilder)
        {
            try
            {
                if (childRequest.GoodDeeds > childRequest.BadDeeds)
                {
                    if (childRequest.Sex == Sex.Male)
                    {
                        if (!File.Exists(@"./male toys.txt"))
                            throw new FileNotFoundException("File with male toys is not found");
                        if (!File.Exists(@"./male edible gifts.txt"))
                            throw new FileNotFoundException("File with male edible gifts is not found");
                        if (!File.Exists(@"./male wishes.txt"))
                            throw new FileNotFoundException("File with male wishes is not found");

                        StreamReader maleToys = new StreamReader(@"./male toys.txt");
                        StreamReader maleEdibleGifts = new StreamReader(@"./male edible gifts.txt");
                        StreamReader maleWishes = new StreamReader(@"./male wishes.txt");
                        string[] maleToysContent = maleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                        string[] maleEdibleGiftsContent = maleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                        string[] maleWishesContent = maleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                        if (maleToysContent.Length <= 1 && maleToysContent[0] == "")
                            throw new ArgumentException("File with male toys is empty");
                        if (maleEdibleGiftsContent.Length <= 1 && maleEdibleGiftsContent[0] == "")
                            throw new ArgumentException("File with male edible gifts is empty");
                        if (maleWishesContent.Length <= 1 && maleWishesContent[0] == "")
                            throw new ArgumentException("File with male wishes is empty");

                        Random random = new Random();
                        giftBuilder.FormToy(maleToysContent[random.Next(0, maleToysContent.Length)]);
                        giftBuilder.FormEdibleGift(maleEdibleGiftsContent[random.Next(0, maleEdibleGiftsContent.Length)]);
                        giftBuilder.FormWish(maleWishesContent[random.Next(0, maleWishesContent.Length)]);
                    }
                    else if (childRequest.Sex == Sex.Female)
                    {
                        if (!File.Exists(@"./female toys.txt"))
                            throw new FileNotFoundException("File with female toys is not found");
                        if (!File.Exists(@"./female edible gifts.txt"))
                            throw new FileNotFoundException("File with female edible gifts is not found");
                        if (!File.Exists(@"./female wishes.txt"))
                            throw new FileNotFoundException("File with female wishes is not found");

                        StreamReader femaleToys = new StreamReader(@"./female toys.txt");
                        StreamReader femaleEdibleGifts = new StreamReader(@"./female edible gifts.txt");
                        StreamReader femaleWishes = new StreamReader(@"./female wishes.txt");
                        string[] femaleToysContent = femaleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                        string[] femaleEdibleGiftsContent = femaleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                        string[] femaleWishesContent = femaleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                        if (femaleToysContent.Length <= 1 && femaleToysContent[0] == "")
                            throw new ArgumentException("File with female toys is empty");
                        if (femaleEdibleGiftsContent.Length <= 1 && femaleEdibleGiftsContent[0] == "")
                            throw new ArgumentException("File with female edible gifts is empty");
                        if (femaleWishesContent.Length <= 1 && femaleWishesContent[0] == "")
                            throw new ArgumentException("File with female wishes is empty");

                        Random random = new Random();
                        giftBuilder.FormToy(femaleToysContent[random.Next(1, femaleToysContent.Length)]);
                        giftBuilder.FormEdibleGift(femaleEdibleGiftsContent[random.Next(1, femaleEdibleGiftsContent.Length)]);
                        giftBuilder.FormWish(femaleWishesContent[random.Next(1, femaleWishesContent.Length)]);
                    }
                }
                else
                {
                    giftBuilder.FormToy("Birch");
                    giftBuilder.FormWish("Be polite");
                }
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

        public static void SecondOption(ChildRequest childRequest, GiftBuilder giftBuilder)
        {
            try
            {
                if (childRequest.Sex == Sex.Male)
                {
                    if (!File.Exists(@"./male toys.txt"))
                        throw new FileNotFoundException("File with male toys is not found");
                    if (!File.Exists(@"./male edible gifts.txt"))
                        throw new FileNotFoundException("File with male edible gifts is not found");
                    if (!File.Exists(@"./male wishes.txt"))
                        throw new FileNotFoundException("File with male wishes is not found");

                    StreamReader maleToys = new StreamReader(@"./male toys.txt");
                    StreamReader maleEdibleGifts = new StreamReader(@"./male edible gifts.txt");
                    StreamReader maleWishes = new StreamReader(@"./male wishes.txt");
                    string[] maleToysContent = maleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    string[] maleEdibleGiftsContent = maleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    string[] maleWishesContent = maleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    if (maleToysContent.Length <= 1 && maleToysContent[0] == "")
                        throw new ArgumentException("File with male toys is empty");
                    if (maleEdibleGiftsContent.Length <= 1 && maleEdibleGiftsContent[0] == "")
                        throw new ArgumentException("File with male edible gifts is empty");
                    if (maleWishesContent.Length <= 1 && maleWishesContent[0] == "")
                        throw new ArgumentException("File with male wishes is empty");

                    if (toysCount == maleToysContent.Length)
                        toysCount = 0;
                    if (edibleCount == maleEdibleGiftsContent.Length)
                        edibleCount = 0;
                    if (wishesCount == maleWishesContent.Length)
                        wishesCount = 0;
                    giftBuilder.FormToy(maleToysContent[toysCount]);
                    giftBuilder.FormEdibleGift(maleEdibleGiftsContent[edibleCount]);
                    giftBuilder.FormWish(maleWishesContent[wishesCount]);
                    ++toysCount;
                    ++edibleCount;
                    ++wishesCount;
                }
                else if (childRequest.Sex == Sex.Female)
                {
                    if (!File.Exists(@"./female toys.txt"))
                        throw new FileNotFoundException("File with female toys is not found");
                    if (!File.Exists(@"./female edible gifts.txt"))
                        throw new FileNotFoundException("File with female edible gifts is not found");
                    if (!File.Exists(@"./female wishes.txt"))
                        throw new FileNotFoundException("File with female wishes is not found");

                    StreamReader femaleToys = new StreamReader(@"./female toys.txt");
                    StreamReader femaleEdibleGifts = new StreamReader(@"./female edible gifts.txt");
                    StreamReader femaleWishes = new StreamReader(@"./female wishes.txt");
                    string[] femaleToysContent = femaleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    string[] femaleEdibleGiftsContent = femaleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    string[] femaleWishesContent = femaleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    if (femaleToysContent.Length <= 1 && femaleToysContent[0] == "")
                        throw new ArgumentException("File with female toys is empty");
                    if (femaleEdibleGiftsContent.Length <= 1 && femaleEdibleGiftsContent[0] == "")
                        throw new ArgumentException("File with female edible gifts is empty");
                    if (femaleWishesContent.Length <= 1 && femaleWishesContent[0] == "")
                        throw new ArgumentException("File with female wishes is empty");

                    if (toysCount == femaleToysContent.Length)
                        toysCount = 0;
                    if (edibleCount == femaleEdibleGiftsContent.Length)
                        edibleCount = 0;
                    if (wishesCount == femaleWishesContent.Length)
                        wishesCount = 0;
                    giftBuilder.FormToy(femaleToysContent[toysCount]);
                    giftBuilder.FormEdibleGift(femaleEdibleGiftsContent[edibleCount]);
                    giftBuilder.FormWish(femaleWishesContent[wishesCount]);
                    ++toysCount;
                    ++edibleCount;
                    ++wishesCount;
                }
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
    }
}
