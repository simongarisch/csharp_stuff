// csc linq_examples.cs && linq_examples && del linq_examples.exe
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;


interface IExample {
    void Run();
}


class CsvExample : IExample {
    public void Run() {
        var strCsv = File.ReadLines("linq_examples.csv");
        var results = from str in strCsv
            let tmp = str.Split(',')
            .Skip(1)
            .Select(x => Convert.ToInt32(x))
            select new {
                Max = tmp.Max(),
                Min = tmp.Min(),
                Total = tmp.Sum(),
                Avg = tmp.Average()
            };
        
        var query = results.ToList();
        foreach(var x in query) {
            Console.WriteLine(
                string.Format("Maximum: {0}, " +
                              "Minimum: {1}, " + 
                              "Total: {2}, " + 
                              "Average: {3}",
                              x.Max, x.Min, x.Total, x.Avg
                )
            );
        }

        /*
        CsvExample
        Maximum: 200, Minimum: 118, Total: 594, Average: 148.5
        Maximum: 191, Minimum: 129, Total: 646, Average: 161.5
        Maximum: 166, Minimum: 34, Total: 453, Average: 113.25
        Maximum: 126, Minimum: 83, Total: 410, Average: 102.5
        Maximum: 174, Minimum: 145, Total: 658, Average: 164.5
        */
    }
}


class DistinctStrings : IExample {
    public void Run() {
        var unique = "Apples,Oranges,Apples,Melons"
            .Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
            .Distinct();
        
        foreach(var item in unique) {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        // Apples Oranges Melons
    }
}


class ParallelExecution : IExample {
    public void Run() {
        IEnumerable<int> oddNums = ((ParallelQuery<int>)ParallelEnumerable.Range(0, 20))
            .Where(x => x % 2 != 0)
            .Select(i => i);

        foreach (int n in oddNums) { Console.Write(n + " "); }
        Console.WriteLine();
        // 5 7 9 11 13 15 17 19 1 3
    }
}


class SequenceDifferent : IExample {
    public void Run() {
        var l1 = new[] {1, 2, 3, 4, 5, 6};
        var l2 = new[] {1, 2, 4, 5};

        var diff = l1.Except(l2);
        Array.ForEach(diff.ToArray(), x => Console.WriteLine(x));
        /*
        3
        6
        */
    }
}


class UpperCaseWords : IExample {
    public void Run() {
        string words = "THIS is A very STRANGE string";
        List<string> results = words.Split(' ')
            .Where(s => String.Equals(s, s.ToUpper(), StringComparison.Ordinal))
            .ToList();

        foreach(string result in results) {
            Console.Write(result + ",");
        }
        Console.WriteLine();

        // THIS,A,STRANGE,
    }
}


class Batching : IExample {
    public void Run() {
        string[] email = {
            "One@gmail.com",
            "Two@gmail.com",
            "Three@gmail.com",
            "Four@gmail.com",
            "Five@gmail.com",
            "Six@gmail.com",
            "Seven@gmail.com",
            "Eight@gmail.com"
        };

        var emailGroup = from i in Enumerable.Range(0, email.Length) group email[i] by i / 3;
        foreach(var group in emailGroup) {
            var all = string.Join(";", group.ToArray());
            Console.WriteLine(all);
            Console.WriteLine("--- Batch Processed ---");
        }
        Console.WriteLine();

        /*
        One@gmail.com;Two@gmail.com;Three@gmail.com
        --- Batch Processed ---
        Four@gmail.com;Five@gmail.com;Six@gmail.com
        --- Batch Processed ---
        Seven@gmail.com;Eight@gmail.com
        --- Batch Processed ---
        */
    }
}

class ToDictionaryEx : IExample {
    class MyClass {
        public bool running;
        public int x;

        public MyClass(bool running, int x) {
            this.running = running;
            this.x = x;
        }
    }

    public void Run() {
        var items = new List<MyClass>() {
            new MyClass(true, 1),
            new MyClass(true, 2),
            new MyClass(false, 3),
            new MyClass(false, 4)
        };

        var dict = items.ToDictionary(item => item.x);
        foreach(var entry in dict) {
            Console.WriteLine(entry);
        }
        /*
        [1, ToDictionaryEx+MyClass]
        [2, ToDictionaryEx+MyClass]
        [3, ToDictionaryEx+MyClass]
        [4, ToDictionaryEx+MyClass]
        */
    }
}

class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new CsvExample());
        examples.Add(new DistinctStrings());
        examples.Add(new ParallelExecution());
        examples.Add(new SequenceDifferent());
        examples.Add(new UpperCaseWords());
        examples.Add(new Batching());
        examples.Add(new ToDictionaryEx());

        foreach(IExample example in examples) {
            Console.WriteLine(example.GetType().Name);
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
