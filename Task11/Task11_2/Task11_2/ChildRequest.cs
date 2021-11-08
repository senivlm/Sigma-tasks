using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    enum Sex { Male, Female }
    class ChildRequest
    {
        private string name;

        private Sex sex;

        private int goodDeeds;

        private int badDeeds;

        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    if (value == "" || value == null)
                        throw new ArgumentException("Child request name is empty");
                    name = value;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Sex Sex
        {
            get { return sex; }
            set 
            {
                sex = value;
            }
        }

        public int GoodDeeds
        {
            get { return goodDeeds; }
            set
            {
                try
                {
                    if (value < 0)
                        throw new ArgumentException("Incorrect number of good deeds");
                    goodDeeds = value;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int BadDeeds
        {
            get { return badDeeds; }
            set
            {
                try
                {
                    if (value < 0)
                        throw new ArgumentException("Incorrect number of bad deeds");
                    badDeeds = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public ChildRequest()
        {
            name = null;
            sex = Sex.Male;
            goodDeeds = 0;
            badDeeds = 0;
        }

        public ChildRequest(string name, Sex sex, int goodDeeds, int badDeeds)
        {
            this.name = name;
            this.sex = sex;
            this.goodDeeds = goodDeeds;
            this.badDeeds = badDeeds;
        }
    }
}
