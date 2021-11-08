using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class GirlishGiftBuilder : GiftBuilder
    {
        public override void FormToy(string name)
        {
            gift.Toy = name;
        }

        public override void FormEdibleGift(string name)
        {
            gift.EdibleGift = name;
        }

        public override void FormWish(string wish)
        {
            gift.Wish = wish;
        }
    }
}
