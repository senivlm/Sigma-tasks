using System;

namespace Task11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ChildRequest childRequest = new ChildRequest("Vladyslav", Sex.Male, 37, 10);
            SaintNicholas saintNicholas = SaintNicholas.GetInstance();
            saintNicholas.GiftBuilder = new GirlishGiftBuilder();
            saintNicholas.OnFormGift += GiftFormingOptions.SecondOption;
            Gift[] gifts = new Gift[15];
            for (int i = 0; i < gifts.Length; ++i)
            {
                gifts[i] = saintNicholas.FormGift(childRequest);
            }
            for (int i = 0; i < gifts.Length; ++i)
            {
                Console.WriteLine(gifts[i].ToString());
            }
        }
    }
}
