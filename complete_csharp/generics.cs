// csc generics.cs && generics && del generics.exe
using System;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class SomeClass<T> {
    public void Print(T something) {
        Console.WriteLine(something.GetType().Name + " -> " + something);
    }
}

class Generics : IExample {
    public void Run() {
        var s1 = new SomeClass<int>();
        s1.Print(7); // Int32 -> 7

        var s2 = new SomeClass<bool>();
        s2.Print(true); // Boolean -> True

        var s3 = new SomeClass<string>();
        s3.Print("someString"); // String -> someString
    }
}

class Example2 { }

class Example3 : Example2 { }

class Example<T> where T : Example2 {
    public void SomeMethod(T input) {
        Console.WriteLine(input.GetType().Name + " -> " + input);
    }
}

class Another<T, U> where T: Example2 where U: Example2 {
    public void DoSomething(T itemT, U itemU) { }
}

class GenericsConstraints : IExample {
    public void Run() {
        var input = new Example3();

        var e = new Example<Example3>();
        e.SomeMethod(input); // Example3 -> Example3

        var ex2 = new Example2();
        var ex3 = new Example3();

        var another = new Another<Example2,Example3>();
        another.DoSomething(ex2, ex3);
    }
}

class MyExample<T> {
    public static void PrintMessage(T message) {
        Console.WriteLine(message.ToString());
    }
}

class GenericMethods : IExample {
    public void Run() {
        MyExample<string>.PrintMessage("Hi"); // Hi
        MyExample<int>.PrintMessage(7);       // 7
        MyExample<bool>.PrintMessage(true);   // true
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new Generics(),
            new GenericsConstraints(),
            new GenericMethods()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}