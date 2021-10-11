using System;

namespace Task6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SiteMonitoring siteMonitoring = new SiteMonitoring("./input.txt");
            Console.WriteLine(siteMonitoring.GetAllInformationAboutSite());
        }
    }
}
