using System;

namespace PdfHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            string URL = "https://github.com/EbookFoundation/free-programming-books/blob/master/books/free-programming-books.md";
            HtmlSource source = new HtmlSource(URL);
            var links = source.GetLinks();

            Console.WriteLine($"We have {links.Count} links.");
            foreach (var link in links)
            {
                if (link.Link.EndsWith(".pdf"))
                {
                    Console.WriteLine("Downloading: " + link.ToString());
                    try
                    {
                        Downloader.DownloadOne(link);
                        Console.WriteLine("Download Success: " + link.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Download Failed: " + link.ToString());
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
