// csc structural_composite.cs && structural_composite && del structural_composite.exe
using System;
using System.Collections.Generic;


interface IShape {
    void Draw();
}


class Circle : IShape {
    public void Draw() {
        Console.WriteLine("Drawing a circle");
    }
}

class Square : IShape {
    public void Draw() {
        Console.WriteLine("Drawing a square");
    }
}

class Triangle : IShape {
    public void Draw() {
        Console.WriteLine("Drawing a triangle");
    }
}


class Drawing : IShape {
    List<IShape> shapes;

    public Drawing() {
        this.shapes = new List<IShape>();
    }

    public void Add(IShape shape) {
        this.shapes.Add(shape);
    }

    public void Draw() {
        foreach(IShape shape in shapes) {
            shape.Draw();
        }
    }
}


class Program {
    public static void Main() {
        var drawing = new Drawing();
        drawing.Add(new Circle());
        drawing.Add(new Square());
        drawing.Add(new Triangle());

        drawing.Draw();
        /*
        Drawing a circle
        Drawing a square  
        Drawing a triangle
         */
    }
}
