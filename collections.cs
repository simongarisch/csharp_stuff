// csc collections.cs && collections && del collections.exe
using System;
using System.Collections.Generic;


interface IExample {
    void Run();
}


class ListExample : IExample {
    public void Run() {
        // https://www.geeksforgeeks.org/c-sharp-list-class/
        List<string> names = new List<string>();
        names.Add("Matt");
        names.Add("Mark");
        names.Add("Luke");

        names.Remove("Mark");
        foreach (String name in names) {
            Console.WriteLine(name);
        }

        names.Sort();
        names.Reverse();
        names.Clear();
    }
}


class DictionaryExample : IExample {
    public void Run() {
        // https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
        Dictionary<int, string> dict = new Dictionary<int, string>();
        dict.Add(1, "one");
        dict.Add(2, "two");
        dict.Add(3, "three");
        
        dict.Remove(2);
        foreach(KeyValuePair<int, string> ele in dict) {
            Console.WriteLine(ele.Key.ToString() + ": " + ele.Value);
        }

        dict.Clear();
    }
}

class SetExample : IExample {
    public void Run() {
        string[] names = new string[] {"matt", "mark", "matt"};
        HashSet<string> set = new HashSet<string>(names);

        set.Add("simon");
        set.Add("sam");
        set.Remove("mark");

        foreach(string name in set) {
            Console.WriteLine(name);
        }
    }
}


class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new ListExample());
        examples.Add(new DictionaryExample());
        examples.Add(new SetExample());

        foreach (IExample example in examples) {
            example.Run();
            Console.WriteLine("-----");
        }
    }
}