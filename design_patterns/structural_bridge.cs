// csc structural_bridge.cs && structural_bridge && del structural_bridge.exe
// The bridge pattern is about preferring composition over inheritance
using System;


class RGB {
    public readonly int red;
    public readonly int green;
    public readonly int blue;

    public RGB(int red, int green, int blue) {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    public override String ToString() {
        return "(" + this.red + "," + this.green + "," + this.blue +")";
    }
}


class Colour {
    public readonly RGB fill;
    public readonly RGB outline;

    public Colour(RGB fill, RGB outline) {
        this.fill = fill;
        this.outline = outline;
    }

    public override string ToString() {
        return this.fill + " fill with a " + this.outline + " outline";
    }
}


abstract class Shape {
    public readonly Colour colour;

    public Shape(Colour colour) {
        this.colour = colour;
    }

    public abstract void Draw();
}


class Rectangle : Shape {
    public Rectangle(Colour colour) : base(colour) {}

    public override void Draw() {
        Console.WriteLine("Rectangle with colour " + this.colour.ToString());
    }
}


class Square : Shape {
    public Square(Colour colour) : base(colour) {}

    public override void Draw() {
        Console.WriteLine("Square with colour " + this.colour.ToString());
    }
}


class Program {
    public static void Main() {
        RGB fill = new RGB(255, 255, 255);
        RGB outline = new RGB(0, 255, 0);
        Colour colour = new Colour(fill, outline);

        var rectangle = new Rectangle(colour);
        var square = new Square(colour);

        rectangle.Draw(); // Rectangle with colour (255,255,255) fill with a (0,255,0) outline
        square.Draw();    // Square with colour (255,255,255) fill with a (0,255,0) outline 
    }
}
