// csc regex.cs && regex && del regex.exe
// https://regex101.com/
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

interface IExample {
    void Run();
}

class BasicRegex : IExample {
    public void Run() {
        string pattern = @"\d";
        Regex regex = new Regex(pattern);
        Console.WriteLine("Does 2 match pattern: " + regex.IsMatch("2")); // true
        Console.WriteLine("Does a match pattern: " + regex.IsMatch("a")); // false

        pattern = "(the)";
        regex = new Regex(pattern);
        string text = "the quick brown fox jumped over the lazy dog";
        Match match = regex.Match(text);
        MatchCollection matches = regex.Matches(text);

        Console.WriteLine(match.ToString());     // the
        Console.WriteLine(match.GetType().Name); // Match
        Console.WriteLine("-----");
        foreach(Match item in matches) {
            Console.WriteLine(item.ToString());
        }
        // the
        // the

        Console.WriteLine(matches.Count); // 2
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new BasicRegex()           
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
