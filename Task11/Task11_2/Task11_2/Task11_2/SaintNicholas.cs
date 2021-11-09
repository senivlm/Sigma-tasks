using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class SaintNicholas
    {
        private static SaintNicholas instance;

        private GiftBuilder giftBuilder;

        private int optionChoice;

        private SaintNicholas()
        {
            giftBuilder = null;
            optionChoice = 0;
        }

        public static SaintNicholas GetInstance()
        {
            if (instance == null)
            {
                instance = new SaintNicholas();
            }
            return instance;
        }

        public void SetOptionChoice(int optionChoice)
        {
            try
            {
                if (optionChoice <= 0)
                    throw new ArgumentException("Incorrect option choice");
                this.optionChoice = optionChoice;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FormGift(ChildRequest childRequest)
        {
            try
            {
                if (optionChoice == 1)
                {
                    if (childRequest.Sex == Sex.Male)
                    {
                        giftBuilder = new BoyishGiftBuilderFirstOption();
                        if (childRequest.GoodDeeds > childRequest.BadDeeds)
                            (giftBuilder as BoyishGiftBuilderFirstOption).SatisFactoryBehavior = true;
                        else
                            (giftBuilder as BoyishGiftBuilderFirstOption).SatisFactoryBehavior = false;
                    }
                    else if (childRequest.Sex == Sex.Female)
                    {
                        giftBuilder = new GirlishGiftBuilderFirstOption();
                        if (childRequest.GoodDeeds > childRequest.BadDeeds)
                            (giftBuilder as GirlishGiftBuilderFirstOption).SatisFactoryBehavior = true;
                        else
                            (giftBuilder as GirlishGiftBuilderFirstOption).SatisFactoryBehavior = false;
                    }
                    giftBuilder.CreateNewGift();
                    giftBuilder.FormToy();
                    giftBuilder.FormEdibleGift();
                    giftBuilder.FormWish();
                }
                else if (optionChoice == 2)
                {
                    if (childRequest.Sex == Sex.Male)
                    {
                        giftBuilder = new BoyishGiftBuilderSecondOption();
                    }
                    else if (childRequest.Sex == Sex.Female)
                    {
                        giftBuilder = new GirlishGiftBuilderSecondOption();
                    }
                    giftBuilder.CreateNewGift();
                    giftBuilder.FormToy();
                    giftBuilder.FormEdibleGift();
                    giftBuilder.FormWish();
                }
                else
                    throw new ArgumentException("There is no appropriate option");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Gift GetGift()
        {
            return giftBuilder?.GetGift();
        }
    }
}
