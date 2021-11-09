using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class BoyishGiftBuilderSecondOption : GiftBuilder
    {
        private static int toyCount = 0;

        private static int edibleGiftCount = 0;

        private static int wishCount = 0;

        public override void FormToy()
        {
            if (!File.Exists(@"./male toys.txt"))
                throw new FileNotFoundException("File with male toys is not found");

            StreamReader maleToys = new StreamReader(@"./male toys.txt");
            string[] maleToysContent = maleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            if (maleToysContent.Length <= 1 && maleToysContent[0] == "")
                throw new ArgumentException("File with male toys is empty");

            if (toyCount == maleToysContent.Length)
                toyCount = 0;
            gift.Toy = maleToysContent[toyCount];
            ++toyCount;
        }

        public override void FormEdibleGift()
        {
            if (!File.Exists(@"./male edible gifts.txt"))
                throw new FileNotFoundException("File with male edible gifts is not found");

            StreamReader maleEdibleGifts = new StreamReader(@"./male edible gifts.txt");
            string[] maleEdibleGiftsContent = maleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            if (maleEdibleGiftsContent.Length <= 1 && maleEdibleGiftsContent[0] == "")
                throw new ArgumentException("File with male edible gifts is empty");

            if (edibleGiftCount == maleEdibleGiftsContent.Length)
                edibleGiftCount = 0;
            gift.EdibleGift = maleEdibleGiftsContent[edibleGiftCount];
            ++edibleGiftCount;
        }

        public override void FormWish()
        {
            if (!File.Exists(@"./male wishes.txt"))
                throw new FileNotFoundException("File with male wishes is not found");

            StreamReader maleWishes = new StreamReader(@"./male wishes.txt");
            string[] maleWishesContent = maleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            if (maleWishesContent.Length <= 1 && maleWishesContent[0] == "")
                throw new ArgumentException("File with male wishes is empty");

            if (wishCount == maleWishesContent.Length)
                wishCount = 0;
            gift.Wish = maleWishesContent[wishCount];
            ++wishCount;
        }
    }
}
