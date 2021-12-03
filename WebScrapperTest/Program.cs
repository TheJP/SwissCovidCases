using System;
using System.Threading.Tasks;

namespace WebScrapperTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var result = await WebScraper.WebScraper.Scrape();
            Console.WriteLine("{0} {1} {2} {3}", result?.Date, result?.NewConfirmedCases, result?.NewHospitalisations, result?.NewConfirmedDeaths);
        }
    }
}
