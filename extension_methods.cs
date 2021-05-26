// csc extension_methods.cs && extension_methods && del extension_methods.exe
// C# extension method is a static method of a static class, where the "this" modifier is applied to the first parameter.
using System;


public class Class1 {
    public void Display() {
        Console.WriteLine("I'm in Display");
    }

    public void Print() {
        Console.WriteLine("I'm in Print");
    }
}


public static class XX {
    public static void NewMethod(this Class1 ob) {
        Console.WriteLine("Hello, I'm an extended method");
    }
}


class Program {
    public static void Main() {
        Class1 ob = new Class1();
        ob.Display(); // I'm in Display
        ob.Print(); // I'm in Print
        ob.NewMethod(); // Hello, I'm an extended method
    }
}
