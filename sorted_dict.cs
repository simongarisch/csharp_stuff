// csc sorted_dict.cs && sorted_dict && del sorted_dict.exe
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?redirectedfrom=MSDN&view=net-5.0
// https://www.geeksforgeeks.org/sortedset-in-c-sharp-with-examples/
using System;
using System.Collections.Generic;


interface IExample {
    void Run();
}

class SortedDictExample : IExample {
    // Represents a collection of key/value pairs that are sorted on the key.
    public void Run() {
        SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
        dict.Add("one", 1);
        dict.Add("two", 2);
        dict.Add("three", 3);
        dict.Add("four", 4);

        // the Add method throws an exception of the key already exists
        try {
            dict.Add("one", 1);
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); // System.ArgumentException: An entry with the same key already exists...
        }

        if (!dict.ContainsKey("five")) {
            dict.Add("five", 5);
        }
        dict["five"] = 10;

        foreach(KeyValuePair<string,int> kvp in dict) {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        /*
        Key = five, Value = 10
        Key = four, Value = 4
        Key = one, Value = 1
        Key = three, Value = 3
        Key = two, Value = 2
        */
    }
}


class SortedSet : IExample {
    // Represents a collection of key/value pairs that are sorted by key based on the associated IComparer<T> implementation.
    public void Run() {
        int[] numbers = new int[] {1, 3, 4, 2, 2, 3, 5};
        SortedSet<int> set = new SortedSet<int>(numbers);
        set.Add(1);
        set.Add(5);
        set.Remove(4);

        foreach(int i in set) {
            Console.Write(i + ", ");
        }
        Console.WriteLine();
        // 1, 2, 3, 5,
    }
}

class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new SortedDictExample());
        examples.Add(new SortedSet());

        foreach(IExample example in examples) {
            Console.WriteLine(example.GetType().Name);
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
