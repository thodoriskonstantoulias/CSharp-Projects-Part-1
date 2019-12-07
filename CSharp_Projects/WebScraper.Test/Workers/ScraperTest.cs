using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using WebScraper.Builders;
using WebScraper.Data;
using WebScraper.Workers;

namespace WebScraper.Test
{
    [TestClass]
    public class ScraperTest
    {
        private readonly Scraper scraper = new Scraper();

        [TestMethod]
        public void FindCollectionsWithNoParts()
        {
            var content = "some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                                                 .WithData(content)
                                                 .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                                                 .WithRegexOptions(RegexOptions.ExplicitCapture)
                                                 .Build();
            var foundElements = scraper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElements.Count == 1);
            Assert.IsTrue(foundElements[0] == "<a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a>");
        }

        [TestMethod]
        public void FindCollectionsWithTwoParts()
        {
            var content = "some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                                                .WithData(content)
                                                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                                                .WithRegexOptions(RegexOptions.ExplicitCapture)
                                                .WithPart(new ScrapeCriteriaPartBuilder().WithRegex(@">(.*?)</a>").WithRegexOptions(RegexOptions.Singleline)
                                                .Build())
                                                .WithPart(new ScrapeCriteriaPartBuilder().WithRegex(@"href=\""(.*?)\""").WithRegexOptions(RegexOptions.Singleline)
                                                .Build())
                                                .Build();
            var foundElements = scraper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElements.Count == 2);
            Assert.IsTrue(foundElements[0] == "some text");
            Assert.IsTrue(foundElements[1] == "http://domain.com");
        }
    }
}
