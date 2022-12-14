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
            public string NewTestCases { get; }
            public string NewHospitalisations { get; }
            public string NewConfirmedDeaths { get; }
            public string DifferenceSince { get; }

            public Result(DateTime date, string newConfirmedCases, string newTestCases, string newHospitalisations, string newConfirmedDeaths, string differenceSince)
            {
                Date = date;
                NewConfirmedCases = newConfirmedCases;
                NewTestCases = newTestCases;
                NewHospitalisations = newHospitalisations;
                NewConfirmedDeaths = newConfirmedDeaths;
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

            var casesAndTests = cards.Skip(1).First();
            var title = casesAndTests.Descendents<IElement>().Single(e => e.ClassList.Contains("card__title")).TextContent;
            if (title != "Laboratory-⁠⁠confirmed cases and tests")
            {
                throw new InvalidFormatException();
            }
            var casesAndTestKeys = casesAndTests.Descendents<IElement>().Where(e => e.ClassList.Contains("bag-key-value-list__entry-key"));
            var casesKey = casesAndTestKeys.Skip(1).First();
            var testsKey = casesAndTestKeys.Skip(4).First();
            if (!casesKey.TextContent.StartsWith("Difference since") || !testsKey.TextContent.StartsWith("Difference since"))
            {
                throw new InvalidFormatException();
            }
            var casesAndTestValues = casesAndTests.Descendents<IElement>().Where(e => e.ClassList.Contains("bag-key-value-list__entry-value"));
            var newCases = casesAndTestValues.First().TextContent;
            var newTests = casesAndTestValues.Skip(2).First().TextContent;

            var values = cards.Skip(4).Take(2).Select(card =>
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

            if (values.Length != 2 || values[0].Title != "Laboratory-⁠confirmed hospitalisations" || values[1].Title != "Laboratory-⁠confirmed deaths")
            {
                throw new InvalidFormatException();
            }

            // Date is in the subtitle of every card
            var encodedDate = document.QuerySelector(".card__subtitle").TextContent.Trim();
            var prefix = "Source: FOPH – Status: ";
            if (!encodedDate.StartsWith(prefix) || !DateTime.TryParseExact(encodedDate.Remove(0, prefix.Length).Remove(10), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
            {
                throw new InvalidFormatException();
            }

            return new Result(date, newCases, newTests, values[0].Value, values[1].Value, values[0].DifferenceSince);
        }
    }
}
