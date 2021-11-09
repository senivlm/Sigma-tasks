using System;
using System.Collections.Generic;

namespace Task11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ChildRequest> childRequest = new List<ChildRequest>();
            childRequest.Add(new ChildRequest("Vladyslav", Sex.Male, 37, 10));
            childRequest.Add(new ChildRequest("Ann", Sex.Female, 33, 15));
            childRequest.Add(new ChildRequest("Vasyl", Sex.Male, 24, 25));
            childRequest.Add(new ChildRequest("Victoria", Sex.Female, 27, 12));
            childRequest.Add(new ChildRequest("Olenka", Sex.Female, 50, 5));
            childRequest.Add(new ChildRequest("Victor", Sex.Male, 34, 14));
            childRequest.Add(new ChildRequest("Stas", Sex.Male, 20, 18));
            childRequest.Add(new ChildRequest("Svyatoslav", Sex.Male, 37, 20));

            SaintNicholas saintNicholas = SaintNicholas.GetInstance();
            saintNicholas.SetOptionChoice(2);

            GiftStorage giftStorage = GiftStorage.GetInstance();

            foreach (ChildRequest request in childRequest)
            {
                saintNicholas.FormGift(request);
                giftStorage.AddGift(saintNicholas.GetGift());
            }
            Console.WriteLine(giftStorage.ToString());
        }
    }
}
