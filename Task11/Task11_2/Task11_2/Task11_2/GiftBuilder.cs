using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    abstract class GiftBuilder
    {
        protected Gift gift;

        public void CreateNewGift()
        {
            gift = new Gift();
        }

        public Gift GetGift()
        {
            return gift;
        }
        public abstract void FormToy();

        public abstract void FormEdibleGift();

        public abstract void FormWish();
    }
}
