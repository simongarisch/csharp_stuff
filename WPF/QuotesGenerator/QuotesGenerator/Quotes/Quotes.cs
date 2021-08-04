using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesGenerator.Quotes
{
    class Quotes
    {
        private List<string> _quotes = new List<string> {
            "Percy, far from being a fit consort for a prince of the realm, you would bore the lettings off a village idiot",
            "Because the pants haven't been built yet that'll take the job on",
            "Oh, come on, Baldrick. You're going to be an MP for gods sake. I'll just put fraud and sexual deviance...",
            "What about the reality where Hitlier cured cancer, Morty? The answer is, don't think about it",
        };

        public string GetRandomQuote()
        {
            Random rnd = new Random();
            return _quotes[rnd.Next(_quotes.Count)];
        }
    }
}
