using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    enum Month { January = 1, February = 2, March = 3, April = 4, May = 5, June = 6, July = 7, August = 8, September = 9, October = 10, November = 11, December = 12 }
    enum Quarter { QuarterOfMonths_1 = 1, QuarterOfMonths_2 = 2, QuarterOfMonths_3 = 3, QuarterOfMonths_4 = 4 }
    class Flat
    {
        private int flatNumber;
        public int FlatNumber
        {
            get { return flatNumber; }
            set 
            { 
                if (value > 0)
                {
                    flatNumber = value;
                }
            }
        }

        private string ownerSurname;
        public string OwnerSurname
        {
            get { return ownerSurname;; }
        }

        private Tuple<int, int>[] electricityConsumption;

        public Tuple<int, int>[] ElectricityConsumption
        {
            get { return electricityConsumption; }
            set { electricityConsumption = value; }
        }

        public Flat()
        {
            flatNumber = 0;
            ownerSurname = null;
            electricityConsumption = null;
        }
        public Flat(int flatNumber, string ownerSurname)
        {
            this.flatNumber = flatNumber;
            this.ownerSurname = ownerSurname;
        }
        public Flat(int flatNumber, string ownerSurname, int initialElectricityConsumption, int finalElectricityConsumption) : this(flatNumber, ownerSurname)
        {
            electricityConsumption = new Tuple<int, int>[1];
            electricityConsumption[0] = new Tuple<int, int>(initialElectricityConsumption, finalElectricityConsumption);
        }
        public Flat(int flatNumber, string ownerSurname, params int[] array) : this(flatNumber, ownerSurname)
        {
            electricityConsumption = new Tuple<int, int>[array.Length / 2];
            for (int i = 0; i < (array.Length / 2); ++i)
            {
                electricityConsumption[i] = new Tuple<int, int>(array[i * 2], array[(i * 2) + 1]);
            }
        }
        public Flat Copy()
        {
            return (Flat)this.MemberwiseClone();
        }

        public int GetElectricityAmount()
        {
            int result = 0;
            for (int i = 0; i < electricityConsumption.Length; ++i)
            {
                result += (electricityConsumption[i].Item2 - electricityConsumption[i].Item1);
            }
            return result;
        }
    }
}
