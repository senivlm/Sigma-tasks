using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    class SiteMonitoring
    {
        private Client[] clients;
        public Client[] Clients
        {
            get { return clients; }
            set { clients = value; }
        }

        private string mostPopularPeriodOfTime;
        public string MostPopularPeriodOfTime
        {
            get { return mostPopularPeriodOfTime; }
            set { mostPopularPeriodOfTime = value; }
        }
        public Client this[int i]
        {
            get { return clients[i]; }
        }

        public SiteMonitoring()
        {
            clients = null;
        }

        private void Swap(ref int[,] array, int i, int j, ref string [][] info)
        {
            int[] temp = new int[array.GetLength(1)];
            for (int u = 0; u < temp.GetLength(0); ++u)
            {
                temp[u] = array[i, u];
                array[i, u] = array[j, u];
                array[j, u] = temp[u];
            }

            string tempTime = info[i][1];
            info[i][1] = info[j][1];
            info[j][1] = tempTime;

            string tempDay = info[i][2];
            info[i][2] = info[j][2];
            info[j][2] = tempDay;
        }
        public SiteMonitoring(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File not found");

                StreamReader file = new StreamReader(path);
                string text = file.ReadToEnd();
                if (text == "")
                    throw new ArgumentException("File is empty");

                string[] sentences = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                string[][] info = new string[sentences.Length][];
                for (int i = 0; i < sentences.Length; ++i)
                {
                    info[i] = sentences[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (info[i].Length != 3)
                        throw new ArgumentException("Incorrect data in file");

                    string[] numbers = info[i][0].Split('.');
                    if (numbers.Length != 4)
                        throw new ArgumentException("Incorrect count of numbers in IP adress");
                    if (!int.TryParse(numbers[0], out int result1) || !int.TryParse(numbers[1], out int result2) ||
                        !int.TryParse(numbers[2], out int result3) || !int.TryParse(numbers[3], out int result4))
                        throw new ArgumentException("Incorrect format of numbers in IP adress");
                    if (result1 <= 0 || result2 <= 0 || result3 <= 0 || result4 <= 0)
                        throw new ArgumentException("Incorrect numbers in IP adress");

                    string[] infoTime = info[i][1].Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (infoTime.Length != 3)
                        throw new ArgumentException("Incorrect count of numbers in time");
                    if (!int.TryParse(infoTime[0], out int result5) || !int.TryParse(infoTime[1], out int result6) || !int.TryParse(infoTime[2], out int result7))
                        throw new ArgumentException("Incorrect format of numbers in time");
                    if (result5 < 0 || result5 > 23 || result6 < 0 || result6 > 59 || result7 < 0 || result7 > 59)
                        throw new ArgumentException("Incorrect numbers in time");

                    switch (info[i][2])
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                        case "Saturday":
                        case "Sunday":
                            break;
                        default:
                            throw new ArgumentException("Incorrect name of day");
                    }
                }

                int[,] ipNumbers = new int[sentences.Length, 4];
                string[] ipNumbersValue;
                for (int i = 0; i < sentences.Length; ++i)
                {
                    ipNumbersValue = info[i][0].Split('.');
                    ipNumbers[i, 0] = int.Parse(ipNumbersValue[0]);
                    ipNumbers[i, 1] = int.Parse(ipNumbersValue[1]);
                    ipNumbers[i, 2] = int.Parse(ipNumbersValue[2]);
                    ipNumbers[i, 3] = int.Parse(ipNumbersValue[3]);
                }
                int[] temp = new int[4];
                for (int i = 0; i < ipNumbers.GetLength(0); ++i)
                {
                    for (int j = 0; j < (ipNumbers.GetLength(0) - 1); ++j)
                    {
                        if (ipNumbers[i, 0] < ipNumbers[j, 0])
                        {
                            Swap(ref ipNumbers, i, j, ref info);
                        }
                        else if ((ipNumbers[i, 0] == ipNumbers[j, 0]) && (ipNumbers[i, 1] < ipNumbers[j, 1]))
                        {
                            Swap(ref ipNumbers, i, j, ref info);
                        }
                        else if ((ipNumbers[i, 0] == ipNumbers[j, 0]) && (ipNumbers[i, 1] == ipNumbers[j, 1]) && (ipNumbers[i, 2] < ipNumbers[j, 2]))
                        {
                            Swap(ref ipNumbers, i, j, ref info);
                        }
                        else if ((ipNumbers[i, 0] == ipNumbers[j, 0]) && (ipNumbers[i, 1] == ipNumbers[j, 1]) && (ipNumbers[i, 2] == ipNumbers[j, 2]) && (ipNumbers[i, 3] < ipNumbers[j, 3]))
                        {
                            Swap(ref ipNumbers, i, j, ref info);
                        }
                    }
                }
                string[] line = new string[3];
                for (int i = 0; i < ipNumbers.GetLength(0); ++i)
                {
                    line[0] = $"{ipNumbers[i, 0]}.{ipNumbers[i, 1]}.{ipNumbers[i, 2]}.{ipNumbers[i, 3]}";

                    info[i][0] = line[0];
                }

                int uniqueIndex = 0, countUniqueClients = 0;
                for (int i = 0; i < sentences.Length; i = uniqueIndex)
                {
                    for (int j = i; (j <= sentences.Length - 1); ++j)
                    {
                        if (info[i][0].Equals(info[j][0]))
                            ++uniqueIndex;
                        else
                            break;
                    }
                    ++countUniqueClients;
                }
                clients = new Client[countUniqueClients];
                for (int i = 0; i < countUniqueClients; ++i)
                {
                    clients[i] = new Client();
                }

                uniqueIndex = 0;
                int countTimes = 0;
                //Заповнення даними клієнтів
                for (int j = uniqueIndex, startPosition = uniqueIndex, i = 0; j < sentences.Length; j = uniqueIndex, startPosition = uniqueIndex, ++i)
                {
                    for (int u = j; u < (sentences.Length); ++u)        //Кількість повторень унікальних IP адресів
                    {
                        if (info[j][0].Equals(info[u][0]))
                            ++uniqueIndex;
                        else
                            break;
                    }
                    countTimes = uniqueIndex - j;
                    clients[i].IpAddress = info[uniqueIndex - 1][0];
                    clients[i].times = new TimeSpan[countTimes];
                    clients[i].daysVal = new Days[countTimes];
                    clients[i].VisitsNumber = countTimes;
                    string[] timeValues;
                    Days day = Days.Monday;
                    for (int u = startPosition, k = 0; u < (startPosition + countTimes); ++u, ++k)
                    {
                        timeValues = info[u][1].Split(':');
                        clients[i].times[k] = new TimeSpan(int.Parse(timeValues[0]), int.Parse(timeValues[1]), int.Parse(timeValues[2]));
                        switch (info[u][2])
                        {
                            case "Monday":
                                day = Days.Monday;
                                break;
                            case "Tuesday":
                                day = Days.Tuesday;
                                break;
                            case "Wednesday":
                                day = Days.Wednesday;
                                break;
                            case "Thursday":
                                day = Days.Thursday;
                                break;
                            case "Friday":
                                day = Days.Friday;
                                break;
                            case "Saturday":
                                day = Days.Saturday;
                                break;
                            case "Sunday":
                                day = Days.Sunday;
                                break;
                        }
                        clients[i].daysVal[k] = day;
                    }
                }

                Days mostPopularDay = Days.Monday;  //Пошук найпопулярнішого дня для IP адреса
                int daysCount = 0, maxDayCount = 0;
                for (int i = 0; i < clients.Length; ++i)
                {
                    daysCount = 0;
                    maxDayCount = 0;
                    for (int j = 0; j < clients[i].daysVal.Length; ++j)
                    {
                        daysCount = 0;
                        mostPopularDay = clients[i].daysVal[j];
                        for (int u = j; u <clients[i].daysVal.Length;++u)
                        {
                            if (mostPopularDay == clients[i].daysVal[u])
                                ++daysCount;
                        }
                        if (daysCount > maxDayCount)
                        {
                            clients[i].MostPopularDay = mostPopularDay;
                            maxDayCount = daysCount;
                        }
                    }
                }

                TimeSpan mostPopularPeriodOfTime = TimeSpan.Zero;   //Пошук найпопулярнішого періоду в одну годину для IP адреса
                int timesCount = 0, maxTimesCount = 0, difference = 0;
                for (int i = 0; i < clients.Length; ++i)
                {
                    timesCount = 0;
                    maxTimesCount = 0;
                    for (int j = 0; j < clients[i].times.Length; ++j)
                    {
                        timesCount = 0;
                        mostPopularPeriodOfTime = clients[i].times[j];
                        for (int u = j; u < clients[i].times.Length; ++u)
                        {
                            difference = mostPopularPeriodOfTime.Hours - clients[i].times[u].Hours;
                            if (difference == 0)
                                ++timesCount;
                        }
                        if (timesCount > maxTimesCount)
                        {
                            if (mostPopularPeriodOfTime.Hours == 23)
                                clients[i].MostPopularPeriodOfTime = $"{mostPopularPeriodOfTime.Hours}-00";
                            else
                                clients[i].MostPopularPeriodOfTime = $"{mostPopularPeriodOfTime.Hours}-{mostPopularPeriodOfTime.Hours + 1}";
                            maxTimesCount = timesCount;
                        }
                    }
                }

                mostPopularPeriodOfTime = TimeSpan.Zero;
                timesCount = maxTimesCount = difference = 0;
                for (int i = 0; i < clients.Length; ++i)
                {
                    timesCount = 0;
                    for (int j = 0; j < clients[i].times.Length; ++j)
                    {
                        timesCount = 0;
                        mostPopularPeriodOfTime = clients[i].times[j];
                        for (int u = 0; u < clients.Length; ++u)
                        {
                            for (int k = 0; k < clients[u].times.Length; ++k)
                            {
                                difference = mostPopularPeriodOfTime.Hours - clients[u].times[k].Hours;
                                if (difference == 0)
                                    ++timesCount;
                            }
                        }
                        if (timesCount > maxTimesCount)
                        {
                            if (mostPopularPeriodOfTime.Hours == 23)
                                MostPopularPeriodOfTime = $"{mostPopularPeriodOfTime.Hours}-00";
                            else
                                MostPopularPeriodOfTime = $"{mostPopularPeriodOfTime.Hours}-{mostPopularPeriodOfTime.Hours + 1}";
                            maxTimesCount = timesCount;
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetEachIPVisitsNumber()
        {
            string result = "";
            for (int i = 0; i < clients.Length; ++i)
            {
                result += $"IP adress: {clients[i].IpAddress}, number of visits: {clients[i].VisitsNumber}\n";
            }
            return result;
        }

        public string GetEachIPMostPopularDay()
        {
            string result = "";
            for (int i = 0; i < clients.Length; ++i)
            {
                result += $"IP adress: {clients[i].IpAddress}, most popular day: {clients[i].MostPopularDay}\n";
            }
            return result;
        }

        public string GetEachIPMostPopularPeriodOfTime()
        {
            string result = "";
            for (int i = 0; i < clients.Length; ++i)
            {
                result += $"IP adress: {clients[i].IpAddress}, most popular period of time: {clients[i].MostPopularPeriodOfTime}\n";
            }
            return result;
        }

        public string GetMostPopularDay()
        {
            string result = "The most popular one-hour period for a site: " + Convert.ToString(MostPopularPeriodOfTime);
            return result;
        }

        public string GetAllInformationAboutSite()
        {
            string result = "Information about site:\n\n";
            for (int i = 0; i < clients.Length; ++i)
            {
                result += $"IP adress: {clients[i].IpAddress}, number of visits: {clients[i].VisitsNumber}, most popular day: {clients[i].MostPopularDay}, most popular period of time {clients[i].MostPopularPeriodOfTime}\n";
            }
            result += "\nThe most popular one-hour period for a site: " + Convert.ToString(MostPopularPeriodOfTime);
            return result;
        }
    }
}
