using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class GirlishGiftBuilderFirstOption : GiftBuilder
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
                if (!File.Exists(@"./female toys.txt"))
                    throw new FileNotFoundException("File with female toys is not found");

                StreamReader femaleToys = new StreamReader(@"./female toys.txt");
                string[] femaleToysContent = femaleToys.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                if (femaleToysContent.Length <= 1 && femaleToysContent[0] == "")
                    throw new ArgumentException("File with female toys is empty");

                Random random = new Random();
                gift.Toy = femaleToysContent[random.Next(0, femaleToysContent.Length)];
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
                if (!File.Exists(@"./female edible gifts.txt"))
                    throw new FileNotFoundException("File with female edible gifts is not found");

                StreamReader femaleEdibleGifts = new StreamReader(@"./female edible gifts.txt");
                string[] femaleEdibleGiftsContent = femaleEdibleGifts.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                if (femaleEdibleGiftsContent.Length <= 1 && femaleEdibleGiftsContent[0] == "")
                    throw new ArgumentException("File with female edible gifts is empty");

                Random random = new Random();
                gift.EdibleGift = femaleEdibleGiftsContent[random.Next(0, femaleEdibleGiftsContent.Length)];
            }
        }

        public override void FormWish()
        {
            if (satisfactoryBehavior == true)
            {
                if (!File.Exists(@"./female wishes.txt"))
                    throw new FileNotFoundException("File with female wishes is not found");

                StreamReader femaleWishes = new StreamReader(@"./female wishes.txt");
                string[] femaleWishesContent = femaleWishes.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                if (femaleWishesContent.Length <= 1 && femaleWishesContent[0] == "")
                    throw new ArgumentException("File with female wishes is empty");

                Random random = new Random();
                gift.Wish = femaleWishesContent[random.Next(0, femaleWishesContent.Length)];
            }
            else if (satisfactoryBehavior == false)
            {
                gift.Wish = "Be polite";
            }
        }
    }
}
