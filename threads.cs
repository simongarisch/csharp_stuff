// csc threads.cs && threads && del threads.exe
// http://www.albahari.com/threading/
using System;
using System.Threading;


class Program {
    public static void Main() {
        Thread th = Thread.CurrentThread;
        th.Name = "MainThread";
        Console.WriteLine(th.Name); // MainThread

        ThreadStart childRef = new ThreadStart(CallToChildThread);
        Thread childThread = new Thread(childRef);
        childThread.Start();
        childThread.Join();
    }

    public static void CallToChildThread() {
        Console.WriteLine("Child thread starts");
        Thread.Sleep(3000);
        Console.WriteLine("Child thread resumes");
    }
}
