// csc members.cs && members && del members.exe
// https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/program-building-blocks

// The members of a class are either static members or instance members. Static members belong to classes,
// and instance members belong to objects (instances of classes).

using System;

class Members
{
    private static int x = 3;

    static void Main()
    {
        Console.WriteLine(x); // 3, the static variable x
        Console.WriteLine(Doubler(x)); // 6, the static method Doubler

        var namer = new Namer();
        Console.WriteLine(namer.GetName()); // John Doe
        namer.SetName("Jane Doe");
        Console.WriteLine(namer.GetName()); // Jane Doe
    }

    static int Doubler(int x)
    {
        return x * 2;
    }
}

class Namer
{
    private string name = "John Doe"; // instance variable name

    public string GetName() {
        return this.name;
    }

    public void SetName(string name) {
        this.name = name;
    }
}
