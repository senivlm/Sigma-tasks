using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class GirlishGiftBuilderSecondOption : GiftBuilder
    {
        private static int toyCount = 0;

        private static int edibleGiftCount = 0;

        private static int wishCount = 0;

        public override void FormToy()
        {
            if (!File.Exists(@"./female toys.txt"))
                throw new FileNotFoundException("File with female toys is not found");

            StreamReader femaleToys = new StreamReader(@"./female toys.txt");
            string[] femaleToysContent = femaleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            if (femaleToysContent.Length <= 1 && femaleToysContent[0] == "")
                throw new ArgumentException("File with female toys is empty");

            if (toyCount == femaleToysContent.Length)
                toyCount = 0;
            gift.Toy = femaleToysContent[toyCount];
            ++toyCount;
        }

        public override void FormEdibleGift()
        {
            if (!File.Exists(@"./female edible gifts.txt"))
                throw new FileNotFoundException("File with female edible gifts is not found");

            StreamReader femaleEdibleGifts = new StreamReader(@"./female edible gifts.txt");
            string[] femaleEdibleGiftsContent = femaleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            if (femaleEdibleGiftsContent.Length <= 1 && femaleEdibleGiftsContent[0] == "")
                throw new ArgumentException("File with female edible gifts is empty");

            if (edibleGiftCount == femaleEdibleGiftsContent.Length)
                edibleGiftCount = 0;
            gift.EdibleGift = femaleEdibleGiftsContent[edibleGiftCount];
            ++edibleGiftCount;
        }

        public override void FormWish()
        {
            if (!File.Exists(@"./female wishes.txt"))
                throw new FileNotFoundException("File with female wishes is not found");

            StreamReader femaleWishes = new StreamReader(@"./female wishes.txt");
            string[] femaleWishesContent = femaleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            if (femaleWishesContent.Length <= 1 && femaleWishesContent[0] == "")
                throw new ArgumentException("File with female wishes is empty");

            if (wishCount == femaleWishesContent.Length)
                wishCount = 0;
            gift.Wish = femaleWishesContent[wishCount];
            ++wishCount;
        }
    }
}
