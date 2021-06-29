// csc functions.cs && functions && del functions.exe
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

interface IExample {
    void Run();
}

class Constructors : IExample {
    class MyClass {
        int x;
        int y;

        public MyClass() {
            this.x = 0;
            this.y = 0;
        }

        public MyClass(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() {
            return this.x.ToString() + ":" + this.y.ToString();
        }
    }

    public void Run() {
        var example = new MyClass();
        Console.WriteLine(example); // '0:0'

        example = new MyClass(1, 2);
        Console.WriteLine(example); // '1:2'
    }
}

class Finalizers : IExample {
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/destructors
    // https://stackoverflow.com/questions/1850742/why-are-there-finalizers-in-java-and-c
    // finalizers perform cleanup when an object is collected by the garbage collector.

    class MyClass {
        ~MyClass() // finalizer
        {
            Console.WriteLine("bye bye instance... nice knowing ya");
        }
    }

    public void Run() {
        
        var obj = new MyClass();
        // later prints 'bye bye instance... nice knowing ya'
    }
}

class Properties : IExample {
    // longhand...
    private string name; // field
    public string Name {      // property
        get { return name; }  // get method
        set { name = value; } // set method
    }

    // you can comment out the set method to make Name read only, for example
    // C# also provides a way to use short-hand / automatic properties.
    public int X {get; private set;} // set accessor is inaccessible externally

    public void Run() {
        this.Name = "simon";
        Console.WriteLine(this.Name);

        this.X = 7;
        Console.WriteLine(this.X);
    }
}

class Attributes : IExample {
    // https://www.tutorialspoint.com/csharp/csharp_attributes.htm
    [Obsolete("OldMethod is obsolete. Please use NewMethod instead.")]
    static void OldMethod() { }

    static void NewMethod() { } 

    public void Run() {
        OldMethod(); // this will produce a warning...
        NewMethod();
    }
}

class Lambdas : IExample {
    public void Run() {
        Action debug = () => Console.WriteLine("Hello, World!");
        debug();
        debug();

        Action<string> print = (s) => Console.WriteLine(s);
        print("-----");
        print("Hello, World!");
        print("Hello, World!");
    }
}

class FuncDelegate : IExample {
    public void Run() {
        Action<int> print = (i) => Console.WriteLine(i);
        // the last type is the type that we return...
        Func<int, int, int> multiply = (x, y) => { return x * y; };
        print(multiply(2, 3)); // 6

        Func<int, int, string> IntConcat = (x, y) => { return x.ToString() + y.ToString(); };
        Console.WriteLine(IntConcat(2, 3)); // 23
    }
}

class Overloading : IExample {
    public void Run() {
        Example(2);    // 2
        Example(2, 3); // 5
    }

    public void Example(int x) {
        Console.WriteLine(x);
    }

    public void Example(int x, int y) {
        Console.WriteLine(x + y);
    }
}

class Overriding : IExample {
    class C1 {
        public virtual void Print() {
            Console.WriteLine("Hello from C1");
        }
    }

    class C2 : C1 {
        public override void Print() {
            Console.WriteLine("Hello from C2");
        }
    }

    public void Run() {
        var c1 = new C1();
        var c2 = new C2();
        c1.Print(); // 'Hello from C1'
        c2.Print(); // 'Hello from C2'
    }
}

class VariadicFunctions : IExample {
    public void Run() {
        Example("here", "are", "some", "words", "for", "ya"); // 'here are some words for ya'
    }

    public void Example(params string[] words) {
        foreach(string word in words) {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}

class OptionalParameters : IExample {
    public void Run() {
        Print();      // 'hi there'
        Print("ola"); // 'ola' 
    }

    public void Print(string message = "hi there") {
        Console.WriteLine(message);
    }
}

public class C {
    public readonly int x;
    public readonly int y;
    
    public C(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

public static class Extensions {
    public static bool GreaterThan(this int i, int val) {
        if (i > val) {
            return true;
        } else {
            return false;
        }
    }

    public static int Sum(this C c) {
        return c.x + c.y;
    }
}

class ExtensionMethods : IExample {
    // additional custom methods that were not originally included with the class
    public void Run() {
        int x = 7;
        Console.WriteLine(x.GreaterThan(2));  // true
        Console.WriteLine(x.GreaterThan(10)); // false

        var c = new C(1, 2);
        Console.WriteLine(c.Sum()); // 3
    }
}

class AsyncFunctions : IExample {
    // https://blog.stephencleary.com/2012/02/async-and-await.html
    // https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
    // https://stackoverflow.com/questions/9343594/how-to-call-asynchronous-method-from-synchronous-method-in-c
    static string MakeBread() {
        return "Bread ready";
    }

    static string MakeSoup() {
        return "Soup ready";
    }

    static async Task<string> MakeBreadAsync() {
        await Task.Delay(1000);
        return "Bread ready"; 
    }

    static async Task<string> MakeSoupAsync() {
        await Task.Delay(1000);
        return "Soup ready";
    }

    static void MakeDinner() {
        Console.WriteLine("--- Synchronous ---");
        var bread = MakeBread();
        var soup = MakeSoup();
        ShowDinner(bread, soup);

        Console.WriteLine("--- Asynchronous ---");
        Task<string>[] tasks = new[] {MakeBreadAsync(), MakeSoupAsync()};
        Task.WaitAll(tasks);
        ShowDinner(tasks[0].Result, tasks[1].Result);
    }

    static void ShowDinner(params string[] items) {
        foreach(string item in items) {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
    }

    public void Run() {
        MakeDinner();
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new Constructors(),
            new Finalizers(),
            new Properties(),
            new Attributes(),
            new Lambdas(),
            new FuncDelegate(),
            new Overloading(),
            new Overriding(),
            new VariadicFunctions(),
            new OptionalParameters(),
            new ExtensionMethods(),
            new AsyncFunctions()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}