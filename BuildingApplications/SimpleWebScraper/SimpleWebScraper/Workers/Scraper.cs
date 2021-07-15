using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleWebScraper.Data;


namespace SimpleWebScraper.Workers
{
    class Scraper
    {
        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            List<string> scrapedElements = new List<string>();
            MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);

            foreach(Match match in matches)
            {
                if (!scrapeCriteria.Parts.Any())
                {
                    scrapedElements.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach(var part in scrapeCriteria.Parts)
                    {
                        // check on the part.RegexOption which is required to be a string
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.RegexOption.ToString());
                        if (matchedPart.Success)
                        {
                            scrapedElements.Add(matchedPart.Groups[1].Value);
                        }
                    }
                }
            }

            return scrapedElements;
        }
    }
}
