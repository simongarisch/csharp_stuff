// csc behavioral_visitor.cs && behavioral_visitor && del behavioral_visitor.exe
using System;


class Square {
    public readonly int side;

    public Square(int side) {
        this.side = side;
    }

    public void Accept(IVisitor v) {
        v.VisitForSquare();
    }
}


class Circle {
    public readonly int radius;

    public Circle(int radius) {
        this.radius = radius;
    }

    public void Accept(IVisitor v) {
        v.VisitForCircle();
    }
}


class Rectangle {
    public readonly int length;
    public readonly int width;

    public Rectangle(int length, int width) {
        this.length = length;
        this.width = width;
    }

    public void Accept(IVisitor v) {
        v.VisitForRectangle();
    }
}


interface IVisitor {
    void VisitForSquare();
    void VisitForCircle();
    void VisitForRectangle();
}


class AreaCalculator : IVisitor {
    public void VisitForSquare() {
        Console.WriteLine("Calculating area for square");
    }

    public void VisitForCircle() {
        Console.WriteLine("Calculating area for circle");
    }

    public void VisitForRectangle() {
        Console.WriteLine("Calculating area for rectangle");
    }
}


class Program {
    public static void Main() {
        Square square = new Square(2);
        Circle circle = new Circle(3);
        Rectangle rectangle = new Rectangle(2, 3);

        AreaCalculator areaCalculator = new AreaCalculator();
        square.Accept(areaCalculator);
        circle.Accept(areaCalculator);
        rectangle.Accept(areaCalculator);
        /* 
        Calculating area for square
        Calculating area for circle
        Calculating area for rectangle
         */
    }
}
