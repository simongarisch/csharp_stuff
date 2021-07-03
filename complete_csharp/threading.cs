// csc threading.cs && threading && del threading.exe
// dotnet-script threading.cs
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

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

class ForegroundAndBackgroundThreads : IExample {
    public void Run() {
        // by default threads are foreground threads - they keep the application alive if at least one of them in running.
        Thread t1 = new Thread(() => Console.WriteLine("I am t1"));
        Thread t2 = new Thread(() => Console.WriteLine("I am t2"));

        t2.IsBackground = true; // may be abruptly terminated
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}

class ThreadPriority : IExample {
    // https://www.geeksforgeeks.org/c-sharp-thread-priority-in-multithreading/
    public static void ExampleMethod() { }

    public void Run() {
        Thread t = new Thread(ExampleMethod);
    
        //t.Priority = ThreadPriority.Lowest;
        //t.Priority = ThreadPriority.BelowNormal;
        //t.Priority = ThreadPriority.Normal;
        //t.Priority = ThreadPriority.AboveNormal;
        //t.Priority = ThreadPriority.Highest;
    
        t.Start();
        t.Join();
    }
}

class ThreadPooling : IExample {
    static void Example1(object stateInfo) {
        Console.WriteLine("Example 1");
    }

    static void Example2(object stateInfo) {
        Console.WriteLine("Example 2");
    }

    static void Example3(object stateInfo) {
        Console.WriteLine("Example 3");
    }

    public void Run() {
        ThreadPool.QueueUserWorkItem(Example1);
        ThreadPool.QueueUserWorkItem(Example2);
        ThreadPool.QueueUserWorkItem(Example3);
        // Console.WriteLine("Thread count: " + ThreadPool.ThreadCount);

        Thread.Sleep(1000);
    }
}

class ThreadSynch : IExample {
    static int x = 0;
    static int y = 0;
    private static object syncObject = new object();

    static void Example1() {
        Console.WriteLine(1);
        Console.WriteLine(2);
        Console.WriteLine(3);
        Console.WriteLine(4);
        Console.WriteLine(5);
    }

    static void Example2() {
        Console.WriteLine(6);
        Console.WriteLine(7);
        Console.WriteLine(8);
        Console.WriteLine(9);
        Console.WriteLine(10);
    }

    static void Example3() {
        for (int i=0; i<1e6; i++) {
            x++;
        }
    }

    static void Example4() {
        for (int i=0; i<1e6; i++) {
            lock (syncObject) {
                y++;
            }
        }
    }

    public void Run() {
        Thread t1 = new Thread(Example1);
        Thread t2 = new Thread(Example2);

        // note that these are likely to get printed out of order
        t1.Start();
        t2.Start();

        Thread.Sleep(500);
        t1.Join();
        t2.Join();

        Console.WriteLine("-----");
        // now for incrementing some variable...
        Thread thread1 = new Thread(Example3);
        Thread thread2 = new Thread(Example3); // no locking here
        thread1.Start();
        thread2.Start();
        Thread.Sleep(500);
        thread1.Join();
        thread2.Join();
        Console.WriteLine(x); // 1,278,953, but will change

        Console.WriteLine("-----");
        // now for incrementing some variable...
        Thread thread3 = new Thread(Example4);
        Thread thread4 = new Thread(Example4); // locking applied
        thread3.Start();
        thread4.Start();
        Thread.Sleep(500);
        thread3.Join();
        thread4.Join();
        Console.WriteLine(y); // 2,000,000
    }
}

class ParallelProgramming : IExample {
    public void Run() {
        // invoking functions in parallel
        Parallel.Invoke(
            () => new WebClient().DownloadFile("http://www.google.com", "google.html"),
            () => new WebClient().DownloadFile("http://www.microsoft.com/", "microsoft.html")
        );

        // loop in parallel
        Parallel.For(0, 10, i => Console.WriteLine("In parallel..."));
    }
}

class ConcurrentCollections : IExample {
    // thread safe collections
    // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
    // https://stackoverflow.com/questions/2980283/thread-safe-collections-in-net
    public void Run() {
        var bag = new ConcurrentBag<int>();
        var tasks = new List<Task>();
        for(int i=0; i<10; i++) {
            var numberToAdd = i;
            tasks.Add(Task.Run(() => bag.Add(numberToAdd)));
        }
        Task.WaitAll(tasks.ToArray());

        List<Task> runningTasks = new List<Task>();
        int numberOfItems = 0;
        while(!bag.IsEmpty) {
            runningTasks.Add(Task.Run(
                () => {
                    int item;
                    if(bag.TryTake(out item)) {
                        Console.WriteLine(item);
                        numberOfItems++;
                    }
                }
            ));
        }
        Task.WaitAll(runningTasks.ToArray());
        Console.WriteLine("There were " + numberOfItems + " items in the bag");
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new BasicExample(),
            new ForegroundAndBackgroundThreads(),
            new ThreadPriority(),
            new ThreadPooling(),
            new ThreadSynch(),
            new ParallelProgramming(),
            new ConcurrentCollections()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
