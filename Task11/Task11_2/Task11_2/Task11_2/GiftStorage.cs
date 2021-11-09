using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class GiftStorage
    {
        private static GiftStorage instance;

        private List<Gift> gifts;

        private GiftStorage()
        {
            gifts = new List<Gift>();
        }

        public static GiftStorage GetInstance()
        {
            if (instance == null)
            {
                instance = new GiftStorage();
            }
            return instance;
        }

        public void AddGift(Gift gift)
        {
            gifts.Add(gift);
        }

        public override string ToString()
        {
            string result = "";
            foreach (Gift gift in gifts)
            {
                result += gift.ToString() + "\n";
            }
            return result;
        }
    }
}
