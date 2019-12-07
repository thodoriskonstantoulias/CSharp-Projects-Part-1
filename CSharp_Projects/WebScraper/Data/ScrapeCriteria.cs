using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WebScraper.Data
{
    public class ScrapeCriteria
    {
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
        public List<ScrapeCriteriaPart> Parts { get; set; }

        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }
    }
}
