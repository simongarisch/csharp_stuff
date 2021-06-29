// csc advanced.cs && advanced && del advanced.exe
using System;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class PreprocessorDirectives : IExample {
    public void Run() {
        #region
        Console.WriteLine("Nothing to see here...");
        #endregion
    }
}

class Delegates : IExample {
    delegate void Print();

    public void Run() {
        Print helloWorld = HelloWorld;
        helloWorld(); // Hello, World!

        helloWorld = GoodbyeWorld;
        helloWorld(); // Goodbye, World!

        Print print = null;
        print += HelloWorld;
        print += GoodbyeWorld;
        print();
        /*
        Hello, World!
        Goodbye, World!
        */
    }

    void HelloWorld() {
        Console.WriteLine("Hello, World!");
    }

    void GoodbyeWorld() {
        Console.WriteLine("Goodbye, World!");
    }
}

class Events : IExample {
    private static event EventHandler evt;

    public static void HandleEvent(object sender, EventArgs evtArgs) {
        Console.WriteLine("Event handled...");
    }

    public void Run() {
        evt += HandleEvent;
        evt.Invoke(null, new EventArgs());
    }

    ~Events() { // unsubscribe from the event (in the finalizer)
        evt -= HandleEvent;
    }
}

class Actions : IExample {
    private static Action<int, int> action;

    static void HandleAction(int int1, int int2) {
        Console.WriteLine("Action Handled");
        Console.WriteLine("Sum: " + (int1 + int2).ToString());
    }

    public void Run() {
        action += HandleAction;
        action.Invoke(2, 3);
    }
}

class Recursion : IExample {
    static int fib(int n) {
        if (n == 0 || n == 1) {
            return n;
        }

        return fib(n-1) + fib(n-2);
    }

    public void Run() {
        for(int i=0; i<=10; i++) {
            Console.Write(fib(i) + " "); // 0 1 1 2 3 5 8 13 21 34 55
        }
        Console.WriteLine();
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new PreprocessorDirectives(),
            new Delegates(),
            new Events(),
            new Actions(),
            new Recursion()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
