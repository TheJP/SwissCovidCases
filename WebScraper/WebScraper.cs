using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    public class WebScraper
    {
        public class Result
        {
            public DateTime Date { get; }
            public string NewConfirmedCases { get; }
            public string NewHospitalisations { get; }
            public string NewConfirmedDeaths { get; }
            public string FullyVaccinatedPeople { get; }
            public string DifferenceSince { get; }

            public Result(DateTime date, string newConfirmedCases, string newHospitalisations, string newConfirmedDeaths, string fullyVaccinatedPeople, string differenceSince)
            {
                Date = date;
                NewConfirmedCases = newConfirmedCases;
                NewHospitalisations = newHospitalisations;
                NewConfirmedDeaths = newConfirmedDeaths;
                FullyVaccinatedPeople = fullyVaccinatedPeople;
                DifferenceSince = differenceSince;
            }
        }

        public class InvalidFormatException : Exception
        {
            public InvalidFormatException() : base("Website Layout different to assumptions") { }
        }

        /// <summary>
        /// Quick and dirty scraping. Trying to throw an exception if the format of the website changes, so that no wrong values are returned.
        /// </summary>
        /// <returns></returns>
        public static async Task<Result?> Scrape()
        {
            var context = new BrowsingContext(Configuration.Default.WithDefaultLoader());
            var document = await context.OpenAsync("https://www.covid19.admin.ch/en/overview");

            var cards = document.QuerySelectorAll(".card");
            if (cards.Length == 0)
            {
                return null;
            }

            var values = cards.Take(3).Select(card =>
            {
                var title = card.Descendents<IElement>().Single(e => e.ClassList.Contains("card__title"));
                var key = card.Descendents<IElement>().First(e => e.ClassList.Contains("bag-key-value-list__entry-key"));
                if (!key.TextContent.StartsWith("Difference since"))
                {
                    throw new InvalidFormatException();
                }
                var value = card.Descendents<IElement>().First(e => e.ClassList.Contains("bag-key-value-list__entry-value"));
                return (Title: title.TextContent, Value: value.TextContent, DifferenceSince: key.TextContent);
            }).ToArray();

            if (values.Length != 3 || values[0].Title != "Laboratory-⁠confirmed cases" || values[1].Title != "Laboratory-⁠confirmed hospitalisations" || values[2].Title != "Laboratory-⁠confirmed deaths")
            {
                throw new InvalidFormatException();
            }

            var vaccinated = cards.Skip(3).Take(1).Select(card =>
            {
                var title = card.Descendents<IElement>().Single(e => e.ClassList.Contains("card__title"));
                if (title.TextContent != "Vaccinated people")
                {
                    throw new InvalidFormatException();
                }

                var key = card.Descendents<IElement>().Where(e => e.ClassList.Contains("bag-key-value-list__entry-key")).Skip(3).First();
                if (key.TextContent != "Fully vaccinated")
                {
                    throw new InvalidFormatException();
                }

                var value = key.Parent.Parent.Descendents<IElement>().Where(e => e.ClassList.Contains("bag-key-value-list__entry-value")).First();
                return value.TextContent;
            }).First();

            // Date is in the subtitle of every card
            var encodedDate = document.QuerySelector(".card__subtitle").TextContent.Trim();
            var prefix = "Source: FOPH – Status: ";
            if (!encodedDate.StartsWith(prefix) || !DateTime.TryParseExact(encodedDate.Remove(0, prefix.Length).Remove(10), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
            {
                throw new InvalidFormatException();
            }

            return new Result(date, values[0].Value, values[1].Value, values[2].Value, vaccinated, values[0].DifferenceSince);
        }
    }
}
