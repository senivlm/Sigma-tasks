using System;
using System.Collections.Generic;
using System.Text;

namespace Task11_2
{
    class Gift
    {
        private string toy;

        private string edibleGift;

        private string wish;

        public string Toy
        {
            get { return toy; }
            set
            {
                try
                {
                    if (value == "" || value == null)
                        throw new ArgumentException("Empty input name of toy");
                    toy = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string EdibleGift
        {
            get { return edibleGift; }
            set
            {
                try
                {
                    if (value == "" || value == null)
                        throw new ArgumentException("Empty input name of toy");
                    edibleGift = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string Wish
        {
            get { return wish; }
            set
            {
                try
                {
                    if (value == "" || value == null)
                        throw new ArgumentException("Empty input name of toy");
                    wish = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Gift()
        {
            toy = null;
            edibleGift = null;
            wish = null;
        }

        public Gift(string toy, string edibleGift, string wish)
        {
            this.toy = toy;
            this.edibleGift = edibleGift;
            this.wish = wish;
        }

        public override string ToString()
        {
            if (EdibleGift != null)
            {
                return $"Toy: {Toy}, edible gift: {EdibleGift}, wish: {Wish}";
            }
            else
            {
                return $"Toy: {Toy}, wish: {Wish}";
            }
        }
    }
}
