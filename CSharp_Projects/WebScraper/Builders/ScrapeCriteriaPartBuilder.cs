
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WebScraper.Data;

namespace WebScraper.Builders
{
    public class ScrapeCriteriaPartBuilder
    {
        private string _regex { get; set; }
        private RegexOptions _regexOption { get; set; }

        public ScrapeCriteriaPartBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }
        public ScrapeCriteriaPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        public ScrapeCriteriaPartBuilder WithRegexOptions(RegexOptions regexOprtions)
        {
            _regexOption = regexOprtions;
            return this;
        }
        public ScrapeCriteriaPart Build()
        {
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart();
            scrapeCriteriaPart.Regex = _regex;
            scrapeCriteriaPart.RegexOption = _regexOption;
            return scrapeCriteriaPart;
        }
    }
}
