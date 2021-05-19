// csc ref.cs && ref && del ref.exe
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref
// The ref keyword indicates that a value is passed by reference.
using System;


class Program {
    public static void Main() {
        var x = 1;

        Program.ByValExample(x);
        Console.WriteLine(x); // 1

        Program.ByRefExample(ref x);
        Console.WriteLine(x); // 2
    }

    public static void ByRefExample(ref int x) {
        x++;
    }

    public static void ByValExample(int x) {
        x++;
    }
}