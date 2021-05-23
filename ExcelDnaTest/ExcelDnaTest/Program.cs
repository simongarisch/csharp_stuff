// PM> Install-Package ExcelDna.AddIn
using System;
using ExcelDna.Integration;



public static class MyFunctions {
    [ExcelFunction(Description = "My first .NET function")]
    public static string SayHello(string name) {
        return "Hello, " + name;
    }
}


class Program {
    public static void Main() {
        Console.WriteLine("Should be good to go...");
    }
}
