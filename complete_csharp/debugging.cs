// csc debugging.cs && debugging && del debugging.exe
using System;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class NullReferenceException : IExample {
    class MyClass {
        public void Run() { }
    }

    MyClass obj;

    public void Run() {
        try {
            obj.Run(); // null reference exception runtime error
        } catch (System.NullReferenceException e) {
            Console.WriteLine(e.ToString());
        }

        this.obj = new MyClass(); // oops, too late
    }
}

class DivideByZeroException : IExample {
    public void Run() {
        try {
            int x = 7;
            int y = 0;
            int z = x / y;
        } catch (System.DivideByZeroException e) {
            Console.WriteLine(e.ToString());
        }
    }
}

class StackOverflowException : IExample {
    public void Run() {
        try {
            // BubblingOver(7); // Process is terminated due to StackOverflowException.
        } catch (System.StackOverflowException e) {
            Console.WriteLine(e.ToString());
        }
    }

    private static int BubblingOver(int x) {
        return BubblingOver(x);
    }
}

class IndexOutOfRangeException : IExample {
    public void Run() {
        var items = new int[] { 1, 2, 3 };
        try {
            int x = items[3];
        } catch (System.IndexOutOfRangeException e) {
            Console.WriteLine(e.ToString());
        }
    }
}

class TryCatchFinallyThrow : IExample {
    public void Run() {
        try {
            // risky code goes here
        } catch (System.NullReferenceException) {
            // handle our caught error
        } catch (System.DivideByZeroException) {
            // we can have multiple catches
        } catch (Exception e) {
            // code to handle the exception goes here
            Console.WriteLine(e.ToString());
        } finally {
            // cleanup goes here
        }

        try {
            throw new System.StackOverflowException("gday there mate");
        } catch (System.StackOverflowException e) {
            Console.WriteLine(e.ToString());
        }
    }
}

class ExceptionClass : IExample {
    class InvalidStudentNameException : System.Exception {
        public InvalidStudentNameException() { }

        public InvalidStudentNameException(string name) : base(string.Format("Invalid Student Name: {0}", name))
        {

        }
    }

    public void Run() {
        try {
            throw new InvalidStudentNameException("Bob");
        } catch (InvalidStudentNameException e) {
            Console.WriteLine(e.ToString());
        }
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample>() {
            new NullReferenceException(),
            new DivideByZeroException(),
            new StackOverflowException(),
            new IndexOutOfRangeException(),
            new TryCatchFinallyThrow(),
            new ExceptionClass()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name);
            example.Run();
            Console.WriteLine("==========");
        }
    }
}