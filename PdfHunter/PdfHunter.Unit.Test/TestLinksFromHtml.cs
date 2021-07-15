using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PdfHunter;

namespace PdfHunter.Unit.Test
{
    [TestClass]
    public class TestLinksFromHtml
    {
        [TestMethod]
        public void TestGetLinks()
        {
            string html = @"
            <li><a href=""http://code.google.com/p/graphbook/"" rel=""nofollow"">Algorithmic Graph Theory</a></li>
            <li><a href=""https://en.wikibooks.org/wiki/Algorithms"" rel =""nofollow"">Algorithms</a>-Wikibooks</li>
            <li><a href=""http://algs4.cs.princeton.edu/home/"" rel = ""nofollow"">Algorithms, 4th Edition</a>-Robert Sedgewick and Kevin Wayne</li>";

            var links = LinksFromHtml.GetLinks(html);
            Assert.IsTrue(links.Count == 3);
            Assert.IsTrue(links[0].Name.Equals("Algorithmic Graph Theory"));
            Assert.IsTrue(links[0].Link.Equals("http://code.google.com/p/graphbook/"));
        }
    }
}
