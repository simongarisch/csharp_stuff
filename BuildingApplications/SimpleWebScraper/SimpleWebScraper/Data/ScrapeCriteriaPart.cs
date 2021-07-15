using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace SimpleWebScraper.Data
{
    class ScrapeCriteriaPart
    {
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
    }
}
