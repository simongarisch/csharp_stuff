// csc dates.cs && dates && del dates.exe
using System;
using System.Collections.Generic;

interface Example {
    void Run();
}

class Basic : Example {
    public void Run() {
        Console.WriteLine(System.DateTime.Now);  // 28/06/2021 2:16:13 PM

        var dateTime = new DateTime(2021, 1, 19);
        Console.WriteLine(dateTime); // 19/01/2021 12:00:00 AM
    }
}

class BasicTimespan : Example {
    // A TimeSpan is an interval of time which can be positive or negative.
    public void Run() {
        var d1 = new DateTime(2021, 1, 19);
        var d2 = new DateTime(2021, 1, 20);
        
        var ts = d2 - d1;
        Console.WriteLine(ts); // 1.00:00:00
        Console.WriteLine(ts.GetType().Name); // TimeSpan
        Console.WriteLine(ts.Days + " " + ts.Hours + " " + ts.Minutes); // 1 0 0

        ts = new TimeSpan(2, 3, 0);
        Console.WriteLine(ts.Days + " " + ts.Hours + " " + ts.Minutes); // 0 2 3
    }
}

class Formatting : Example {
    public void Run() {
        var dt = DateTime.Now;
        Console.WriteLine(dt); // 28/06/2021 2:24:58 PM
        Console.WriteLine(dt.ToString("MM/dd/yyyy")); // 06/28/2021
        Console.WriteLine(dt.ToString("dddd, dd MMMM yyyy")); // Monday, 28 June 2021
        Console.WriteLine(dt.ToString("dddd, dd MMMM yyyy HH:mm:ss")); // Monday, 28 June 2021 14:28:06
    }
}

class UTC : Example {
    public void Run() {
        Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));    // 06/28/2021 02:31 PM
        Console.WriteLine(DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt")); // 06/28/2021 04:31 AM
    }
}

class Program {
    public static void Main() {
        var examples = new List<Example> {
            new Basic(),
            new BasicTimespan(),
            new Formatting(),
            new UTC()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}