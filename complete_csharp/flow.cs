// csc flow.cs && flow && del flow.exe
using System;
using System.Collections.Generic;

interface Example {
    void Run();
}

class Iffy : Example {
    public void Run() {
        bool hungry = true;
        bool greedy = false;
    
        if (hungry) {
            Console.WriteLine("Check fridge");
        } else if(greedy) {
            Console.WriteLine("Check fridge anyway...");
        } else {
            Console.WriteLine("Carry on...");
        }
    }
}

class Switchy : Example {
    public void Run() {
        int value = 2;

        switch (value) {
            case 1:
                Console.WriteLine("1");
                break;
            case 2:
                Console.WriteLine("2");
                break;
            case 3:
                Console.WriteLine("3");
                break;
            case 4:
                Console.WriteLine("4");
                break;
            case 5:
                Console.WriteLine("5");
                break;
            default:
                Console.WriteLine("Not between 1 and 5 inclusive...");
                break;
        }
    }
}

class Loopy : Example {
    public void Run() {
        for (int i=1; i<=10; i++) {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        string s = "abc";
        for(int i=0; i<s.Length; i++) {
            Console.Write(s[i] + " ");
        }
        Console.WriteLine();

        foreach(char c in s) {
            Console.Write(c + " ");
        }
        Console.WriteLine();

        for (int i=0; i<=3; i++) {
            for (int j=0; j<=3; j++) {
                Console.WriteLine("i:" + i.ToString() + ", j:" + j.ToString());
            }
        }
    }
}

class InAWhile : Example {
    public void Run() {
        int i = 0;
        while (i < 3) {
            Console.WriteLine(i);
            i++;
        }
        Console.WriteLine("=====");

        // do while loop is executed at least once
        i = 0;
        do {
            Console.WriteLine(i);
            i++;
        } while (i < 5);
    }
}

class Program {
    public static void Main() {
        var examples = new List<Example> {
            new Iffy(),
            new Switchy(),
            new Loopy(),
            new InAWhile()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}