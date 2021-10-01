using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Accounting
    {
        private Quarter quarterOfMonths;

        public Quarter QuarterOfMonths
        {
            get { return quarterOfMonths; }
            set { quarterOfMonths = value; }
        }

        private Month[] months;

        public Month[] Months
        {
            get { return months; }
            set { months = value; }
        }

        private Flat[] flats;

        public Flat[] Flats
        {
            get { return flats; }
            set { flats = value; }
        }

        public Flat this[int i]
        {
            get
            {
                if (i < flats.Length)
                {
                    return flats[i];
                }
                throw new IndexOutOfRangeException();
                
            }
            set 
            {
                if (i < flats.Length)
                {
                    flats[i] = value;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public Accounting()
        {
            flats = null;
        }
        public Accounting(string path)
        {
            StreamReader file = new StreamReader(path);
            string[] lineSplit = file.ReadLine().Split();
            if (!int.TryParse(lineSplit[0], out int flatNumber))
                throw new FormatException();
            if (!int.TryParse(lineSplit[1], out int quarterNumber))
                throw new FormatException();

            flats = new Flat[flatNumber];
            if (quarterNumber > 0 && quarterNumber <=4)
            {
                switch (quarterNumber)
                {
                    case 1:
                        quarterOfMonths = Quarter.QuarterOfMonths_1;
                        months = new Month[3];
                        months[0] = Month.January;
                        months[1] = Month.February;
                        months[2] = Month.March;
                        break;
                    case 2:
                        quarterOfMonths = Quarter.QuarterOfMonths_2;
                        months = new Month[3];
                        months[0] = Month.April;
                        months[1] = Month.May;
                        months[2] = Month.June;
                        break;
                    case 3:
                        quarterOfMonths = Quarter.QuarterOfMonths_3;
                        months = new Month[3];
                        months[0] = Month.July;
                        months[1] = Month.August;
                        months[2] = Month.September;
                        break;
                    case 4:
                        quarterOfMonths = Quarter.QuarterOfMonths_4;
                        months = new Month[3];
                        months[0] = Month.October;
                        months[1] = Month.November;
                        months[2] = Month.December;
                        break;
                }
            }
            for (int i = 0; i < flatNumber; ++i)
            {
                string[] data = file.ReadLine().Split();
                flats[i] = new Flat(int.Parse(data[0]), data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
            }
            file.Close();
        }
        public Accounting(Flat flat, Quarter quarter)
        {
            flats = new Flat[1];
            flats[0] = new Flat(flat.FlatNumber, flat.OwnerSurname, flat.ElectricityConsumption[0].Item2, flat.ElectricityConsumption[0].Item1);
            switch (quarter)
            {
                case Quarter.QuarterOfMonths_1:
                    months = new Month[3];
                    months[0] = Month.January;
                    months[1] = Month.February;
                    months[2] = Month.March;
                    break;
                case Quarter.QuarterOfMonths_2:
                    months = new Month[3];
                    months[0] = Month.April;
                    months[1] = Month.May;
                    months[2] = Month.June;
                    break;
                case Quarter.QuarterOfMonths_3:
                    months = new Month[3];
                    months[0] = Month.July;
                    months[1] = Month.August;
                    months[2] = Month.September;
                    break;
                case Quarter.QuarterOfMonths_4:
                    months = new Month[3];
                    months[0] = Month.October;
                    months[1] = Month.November;
                    months[2] = Month.December;
                    break;
            }
        }
        public Accounting(Flat []flats, Quarter quarter)
        {
            this.flats = new Flat[flats.Length];
            for (int i = 0; i < flats.Length; ++i)
            {
                this.flats[i] = flats[i].Copy();
            }
            switch (quarter)
            {
                case Quarter.QuarterOfMonths_1:
                    months = new Month[3];
                    months[0] = Month.January;
                    months[1] = Month.February;
                    months[2] = Month.March;
                    break;
                case Quarter.QuarterOfMonths_2:
                    months = new Month[3];
                    months[0] = Month.April;
                    months[1] = Month.May;
                    months[2] = Month.June;
                    break;
                case Quarter.QuarterOfMonths_3:
                    months = new Month[3];
                    months[0] = Month.July;
                    months[1] = Month.August;
                    months[2] = Month.September;
                    break;
                case Quarter.QuarterOfMonths_4:
                    months = new Month[3];
                    months[0] = Month.October;
                    months[1] = Month.November;
                    months[2] = Month.December;
                    break;
            }
        }
        public override string ToString()
        {
            string result = "_______________________________________________\n";
            result += string.Format("|{0,10}{1,16}{2,16}    |\n", months[0], months[1], months[2]);
            if (flats.Length > 0)
            {
                for (int i = 0; i < flats.Length; ++i)
                {
                    result += string.Format("|{0,4}\t{1,4}\t{2,4}\t{3,4}\t{4,4}\t{5,4}   | Flat number: {6} Owner: {7}\n", flats[i].ElectricityConsumption[0].Item1, flats[i].ElectricityConsumption[0].Item2,flats[i].ElectricityConsumption[1].Item1,
                        flats[i].ElectricityConsumption[1].Item2, flats[i].ElectricityConsumption[2].Item1, flats[i].ElectricityConsumption[2].Item2, flats[i].FlatNumber, flats[i].OwnerSurname);
                }
            }
            result += "|______________________________________________|\n";
            return result;
        }
        public string PrintSingularFlat(int index)
        {
            if (index > 0 && index < (flats.Length + 1))
            {
                string result = "_______________________________________________\n";
                result += string.Format("|{0,10}{1,16}{2,16}    |\n", months[0], months[1], months[2]);
                result += string.Format("|{0,4}\t{1,4}\t{2,4}\t{3,4}\t{4,4}\t{5,4}   | Flat number: {6} Owner: {7}\n", flats[index - 1].ElectricityConsumption[0].Item1,
                    flats[index - 1].ElectricityConsumption[0].Item2, flats[index - 1].ElectricityConsumption[1].Item1,
                    flats[index - 1].ElectricityConsumption[1].Item2, flats[index - 1].ElectricityConsumption[2].Item1,
                    flats[index - 1].ElectricityConsumption[2].Item2, flats[index - 1].FlatNumber, flats[index - 1].OwnerSurname);
                result += "|______________________________________________|\n";
                return result;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public string GetOwnerWithBiggestDebt()
        {
            int[] flatElectricity = new int[flats.Length];
            for (int i = 0; i < flats.Length; ++i)
            {
                flatElectricity[i] = flats[i].GetElectricityAmount();
            }
            int maxElectricityAmount = flatElectricity[0];
            int indexMaxElectricityAmount = 0;
            for (int i = 0; i < flatElectricity.Length; ++i)
            {
                if (maxElectricityAmount < flatElectricity[i])
                {
                    maxElectricityAmount = flatElectricity[i];
                    indexMaxElectricityAmount = i;
                }
            }
            string result = flats[indexMaxElectricityAmount].OwnerSurname + " has the biggest debt";
            return result;
        }
        public int GetFlatNumberWithoutUsingElectricity()
        {
            for (int i = 0; i < flats.Length; ++i)
            {
                if (flats[i].GetElectricityAmount() == 0)
                {
                    return flats[i].FlatNumber;
                }
            }
            return -1;
        }
    }
}
