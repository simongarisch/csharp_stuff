// csc threading.cs && threading && del threading.exe
using System;
using System.Collections.Generic;
using System.Threading;

interface IExample {
    void Run();
}

class BasicExample : IExample {
    void ExampleFunction() {
        for(int i=0; i<=10; i++) {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    public void Run() {
        Thread t = new Thread(ExampleFunction);
        t.Start();
        t.Join();

        Thread someThread = new Thread(() => Console.WriteLine("Hello, World!"));
        someThread.Name = "My thread name";
        someThread.Start();
        someThread.Join();
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new BasicExample()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}