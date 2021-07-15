using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PdfHunter;

namespace PdfHunter.Unit.Test
{
    [TestClass]
    public class TestFreePdfsURL
    {
        [TestMethod]
        public void TestEbookFoundationPdfsAvailable()
        {
            string URL = "https://github.com/EbookFoundation/free-programming-books/blob/master/books/free-programming-books.md";
            HtmlSource source = new HtmlSource(URL);
            var links = source.GetLinks();

            var pdfLinks = new List<FileLink>();
            foreach (var link in links)
            {
                if (link.Link.EndsWith(".pdf"))
                {
                    pdfLinks.Add(link);
                }
            }

            Assert.IsTrue(pdfLinks.Count > 100);
        }
    }
}
