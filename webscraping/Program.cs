// dotnet add package HtmlAgilityPack --version 1.11.33
using System;
using HtmlAgilityPack;

class Program {
    static void Main(string[] args) {
        var web = new HtmlAgilityPack.HtmlWeb();
        string url = "https://www.nuget.org/packages/HtmlAgilityPack/";
        
        try {
            var doc = web.Load(url);
            var tables = doc.DocumentNode.SelectNodes("//table");
            foreach(HtmlNode table in tables) {
                Console.WriteLine("Found: " + table.Id);
                Console.WriteLine(table.InnerText);
            }
        } catch (System.Net.WebException ex){
            Console.WriteLine("Nothing to see here...");
            Console.WriteLine(ex.ToString()); // or log it somewhere...
            return;
        }

    }
}
