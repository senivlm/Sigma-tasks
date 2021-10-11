using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    class Client
    {
        private string ipAddress;
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public TimeSpan[] times;

        public Days[] daysVal;

        private int visitsNumber;
        public int VisitsNumber
        {
            get { return visitsNumber; }
            set 
            {
                try
                {
                    if (!int.TryParse(Convert.ToString(value), out int result))
                        throw new ArgumentException("Incorrect format of visits number");
                    if (value <= 0)
                        throw new ArgumentException("Incorrect visits number");
                    visitsNumber = value;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private Days mostPopularDay;
        public Days MostPopularDay
        {
            get { return mostPopularDay; }
            set { mostPopularDay = value; }
        }

        private string mostPopularPeriodOfTime;
        public string MostPopularPeriodOfTime
        {
            get { return mostPopularPeriodOfTime; }
            set { mostPopularPeriodOfTime = value; }
        }

        public Client()
        {
            ipAddress = null;
            times = null;
            daysVal = null;
        }

        public Client(string ipAddress, TimeSpan time, Days day)
        {
            this.ipAddress = ipAddress;
            this.times = new TimeSpan[1];
            this.times[0] = time;
            this.daysVal = new Days[1];
            daysVal[0] = day;
        }

        public Client(string ipAddress, TimeSpan[] times, Days[] daysVal)
        {
            try
            {
                if ((ipAddress == "") || (ipAddress == null))
                    throw new ArgumentException("Incorrect IP adress");
                this.ipAddress = ipAddress;
                this.times = new TimeSpan[times.Length];
                this.daysVal = new Days[daysVal.Length];
                for (int i = 0; i < times.Length; ++i)
                {
                    this.times[i] = new TimeSpan(times[i].Hours, times[i].Minutes, times[i].Seconds);
                }
                for (int i = 0; i < daysVal.Length; ++i)
                {
                    this.daysVal[i] = daysVal[i];
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Client Copy()
        {
            return (Client)MemberwiseClone();
        }
    }
}
