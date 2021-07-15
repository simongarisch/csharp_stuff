using System;
using System.Net;

namespace PdfHunter
{
    class Downloader
    {
        public static void DownloadOne(FileLink fileLink)
        {
            using (var client = new WebClient())
            {
                string name = fileLink.Name;
                if (!name.EndsWith(".pdf"))
                    name += ".pdf";

                client.DownloadFile(fileLink.Link, name);
            }
        }
    }
}
