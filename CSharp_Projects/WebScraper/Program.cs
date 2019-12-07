using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using WebScraper.Builders;
using WebScraper.Data;
using WebScraper.Workers;

namespace WebScraper
{
    class Program
    {
        private const string Method = "search";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter to city for information scraping");
                var craigslistCity = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Please enter the CraigsList category to scrape");
                var craigslistCategory = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"http://{craigslistCity.Replace(" ", string.Empty)}.craigslist.org/{Method}/{craigslistCategory}");
                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder().WithData(content)
                                                                               .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                                                                               .WithRegexOptions(RegexOptions.ExplicitCapture)
                                                                               .WithPart(new ScrapeCriteriaPartBuilder().WithRegex(@">(.*?)</a>").WithRegexOptions(RegexOptions.Singleline)
                                                                               .Build())
                                                                               .WithPart(new ScrapeCriteriaPartBuilder().WithRegex(@"href=\""(.*?)\""").WithRegexOptions(RegexOptions.Singleline)
                                                                               .Build())
                                                                               .Build();
                    Scraper scraper = new Scraper();
                    var scrapedElements = scraper.Scrape(scrapeCriteria);
                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements)
                        {
                            Console.WriteLine(scrapedElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for the specified criteria");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
