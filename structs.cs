// csc structs.cs && structs && del structs.exe

using System;

public struct Coords
{
    public double X { get; set;}
    public double Y { get; set;}

    public Coords(double x, double y) : this()
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        return "(" + X.ToString() + ", " + Y.ToString() + ")";
    }
}

class Structs
{
    public static void Main() {
        Coords c = new Coords(1, 2);
        Console.WriteLine(c.ToString()); // (1, 2)
    }
}
