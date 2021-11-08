using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class SaintNicholas
    {
        public delegate void FormGiftForChild(ChildRequest childRequest, GiftBuilder giftBuilder);

        public event FormGiftForChild OnFormGift;

        private static SaintNicholas instance;

        private GiftBuilder giftBuilder;

        private SaintNicholas()
        {
            giftBuilder = null;
        }

        public static SaintNicholas GetInstance()
        {
            if (instance == null)
            {
                instance = new SaintNicholas();
            }
            return instance;
        }

        public GiftBuilder GiftBuilder
        {
            get { return giftBuilder; }
            set { SaintNicholas.GetInstance().giftBuilder = value; }
        }

        public Gift FormGift(ChildRequest childRequest)
        {
            SaintNicholas.GetInstance().giftBuilder.CreateNewGift();
            SaintNicholas.GetInstance()?.OnFormGift.Invoke(childRequest, giftBuilder);
            return giftBuilder.GetGift();
        }

        public Gift GetGift()
        {
            return SaintNicholas.GetInstance().giftBuilder.GetGift();
        }
    }
}
