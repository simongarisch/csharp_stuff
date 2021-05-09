// csc types.cs && types && del types.exe
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
using System;

class Types
{

    public static void Main()
    {
        int a = 123;
        Console.WriteLine(a); // 123

        Type type = a.GetType();
        Console.WriteLine(type);  // System.Int32

        bool check = true;
        Console.WriteLine(check ? "Checked" : "Not checked"); // Checked

        double d = 12.3;
        Console.WriteLine(d); // 12.3
    }
}
