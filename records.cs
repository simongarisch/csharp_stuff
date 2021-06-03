// you'll need to run this on >= .NET 5
// csc records.cs && records && del records.exe
// https://dotnetfiddle.net/
using System;

record Person(string FirstName, string LastName);

class Program {
    public static void Main() {
        Person person1 = new("Bob", "Builder");
        Person person2 = new("Bob", "Builder");
        Person person3 = new("Nancy", "Newman");

        Console.WriteLine(person1 == person2); // true
        Console.WriteLine(person3); // Person { FirstName = Nancy, LastName = Newman }
    }
}
