using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;


namespace PdfHunter
{
    public class HtmlSource
    {
        public readonly string URL;

        public HtmlSource(string URL)
        {
            this.URL = URL;
        }

        public List<FileLink> GetLinks()
        {
            var webClient = new WebClient();
            string html = webClient.DownloadString(URL);
            return LinksFromHtml.GetLinks(html);
        }
    }

    public class LinksFromHtml
    {
        public static List<FileLink> GetLinks(string html)
        {
            var links = new List<FileLink>();
            string regex = @"<a.*?href=""(http.*?)"".*?>(.*?)<\/a>"; // see https://regex101.com/
            MatchCollection matchCollection = Regex.Matches(html, regex, RegexOptions.Compiled);
            foreach (Match match in matchCollection)
            {
                FileLink link = new FileLink(match.Groups[2].Value, match.Groups[1].Value);
                links.Add(link);
            }

            return links;
        }
    }
}
