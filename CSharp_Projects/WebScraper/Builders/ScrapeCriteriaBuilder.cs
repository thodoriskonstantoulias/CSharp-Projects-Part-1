using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WebScraper.Data;

namespace WebScraper.Builders
{
    public class ScrapeCriteriaBuilder
    {
        private string _data { get; set; }
        private string _regex { get; set; }
        private RegexOptions _regexOption { get; set; }
        private List<ScrapeCriteriaPart> _parts { get; set; }

        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScrapeCriteriaPart>();
        }

        public ScrapeCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }
        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        public ScrapeCriteriaBuilder WithRegexOptions(RegexOptions regexOptions)
        {
            _regexOption = regexOptions;
            return this;
        }
        public ScrapeCriteriaBuilder WithPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            _parts.Add(scrapeCriteriaPart);
            return this;
        }
        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOption = _regexOption;
            scrapeCriteria.Parts = _parts;
            return scrapeCriteria;
        }
    }
}
