using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class BoyishGiftBuilderFirstOption : GiftBuilder
    {
        private bool satisfactoryBehavior;

        public bool SatisFactoryBehavior
        {
            set { satisfactoryBehavior = value; }
        }
        public override void FormToy()
        {
            if (satisfactoryBehavior == true)
            {
                if (!File.Exists(@"./male toys.txt"))
                    throw new FileNotFoundException("File with male toys is not found");

                StreamReader maleToys = new StreamReader(@"./male toys.txt");
                string[] maleToysContent = maleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                if (maleToysContent.Length <= 1 && maleToysContent[0] == "")
                    throw new ArgumentException("File with male toys is empty");

                Random random = new Random();
                gift.Toy = maleToysContent[random.Next(0, maleToysContent.Length)];
            }
            else if (satisfactoryBehavior == false)
            {
                gift.Toy = "Birch";
            }
        }

        public override void FormEdibleGift()
        {
            if (satisfactoryBehavior == true)
            {
                if (!File.Exists(@"./male edible gifts.txt"))
                    throw new FileNotFoundException("File with male edible gifts is not found");

                StreamReader maleEdibleGifts = new StreamReader(@"./male edible gifts.txt");
                string[] maleEdibleGiftsContent = maleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                if (maleEdibleGiftsContent.Length <= 1 && maleEdibleGiftsContent[0] == "")
                    throw new ArgumentException("File with male edible gifts is empty");

                Random random = new Random();
                gift.EdibleGift = maleEdibleGiftsContent[random.Next(0, maleEdibleGiftsContent.Length)];
            }
        }

        public override void FormWish()
        {
            if (satisfactoryBehavior == true)
            {
                if (!File.Exists(@"./male wishes.txt"))
                    throw new FileNotFoundException("File with male wishes is not found");

                StreamReader maleWishes = new StreamReader(@"./male wishes.txt");
                string[] maleWishesContent = maleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                if (maleWishesContent.Length <= 1 && maleWishesContent[0] == "")
                    throw new ArgumentException("File with male wishes is empty");

                Random random = new Random();
                gift.Wish = maleWishesContent[random.Next(0, maleWishesContent.Length)];
            }
            else if (satisfactoryBehavior == false)
            {
                gift.Wish = "Be polite";
            }
        }
    }
}
