// csc async.cs && async && del async.exe
// https://docs.microsoft.com/en-us/dotnet/csharp/async
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


interface IExample {
    void Run();
}

class BasicExample : IExample {
    // Method1 and Method2 do not wait for each other
    public void Run() {
        #pragma warning disable 4014
        Method1();
        #pragma warning restore 4014
        Method2();
    }

    public async Task Method1() {
        await Task.Run(() => {
            for(int i=0; i<5; i++) {
                Console.WriteLine("Method1");
                Task.Delay(100).Wait();
            }
        });
    }

    public void Method2() {
        for(int i=0; i<5; i++) {
            Console.WriteLine("Method2");
            Task.Delay(100).Wait();
        }
    }
}


class BasicExample2 : IExample {
    public void Run() {
        callMethod();
    }

    public async void callMethod() {
        Task<int> task = Method1();
        Method2();
        int count = await task;
        Method3(count);
    }

    public async Task<int> Method1() {
        int count = 0;
        await Task.Run(() => {
            for (int i=0; i<5; i++) {
                Console.WriteLine("Method1");
                count++;
            }
        });
        return count;
    }

    public void Method2() {
        for (int i=0; i<5; i++) {
            Console.WriteLine("Method2");
        }
    }

    public void Method3(int count) {
        Console.WriteLine("Total count is " + count);
    }
}


class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new BasicExample());
        examples.Add(new BasicExample2());

        foreach(IExample example in examples) {
            Console.WriteLine(example.GetType().Name);
            example.Run();
            Console.WriteLine("==========");
        }
    }
}