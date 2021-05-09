// csc accessibility.cs && accessibility && del accessibility.exe

/*
https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/program-building-blocks

public: Access isn't limited.
private: Access is limited to this class.
protected: Access is limited to this class or classes derived from this class.
internal: Access is limited to the current assembly (.exe or .dll).
protected internal: Access is limited to this class, classes derived from this class, or classes within the same assembly.
private protected: Access is limited to this class or classes derived from this type within the same assembly.

By default, all members of a class are private if you don't specify an access modifier
*/

using System;

class Access
{
    public int a = 1;
    int b = 7;

    public int GetB() {
        return this.b;
    }
}

class MyClass
{
    public static void Main() {
        var obj = new Access();
        Console.WriteLine(obj.a); // 1
        Console.WriteLine(obj.GetB()); // 7

        Console.WriteLine(Color.Red.R); // 255
        Console.WriteLine(Color.Red.G); // 0
        Console.WriteLine(Color.Red.B); // 0
    }
}

public class Color
{
    public static readonly Color Black = new Color(0, 0, 0);
    public static readonly Color White = new Color(255, 255, 255);
    public static readonly Color Red = new Color(255, 0, 0);
    public static readonly Color Green = new Color(0, 255, 0);
    public static readonly Color Blue = new Color(0, 0, 255);
    
    public byte R;
    public byte G;
    public byte B;

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
}
