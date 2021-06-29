// csc collections.cs && collections && del collections.exe
using System;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class Arrays : IExample {
    public void Run() {
        string[] strings = new string[] {"a", "b", "c"};
        Console.WriteLine(strings); // System.String[]

        int[] array = new int[3];
        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        Console.WriteLine("There are " + array.Length + " items"); // There are 3 items
        foreach(var val in array) {
            Console.Write(val + " "); // 1 2 3
        }
        Console.WriteLine();

        string[] sarray = new string[] {"c", "a", "b"};
        Array.Sort(sarray);
        foreach(string s in sarray) {
            Console.Write(s + " ");
        }
        Console.WriteLine();
    }
}

class Lists : IExample {
    public void Run() {
        var numbers = new List<int>() {1, 3, 5, 7, 9};
        Console.WriteLine(numbers.Count); // 5

        numbers.Add(8);
        numbers.Add(10);
        numbers.Add(1);
        numbers.Add(3);
        numbers.Sort();
        foreach(int number in numbers) {
            Console.Write(number + " "); // 1 1 3 3 5 7 8 9 10
        }
        Console.WriteLine();

        numbers.Remove(1);
        foreach(int number in numbers) {
            Console.Write(number + " "); // 1 3 3 5 7 8 9 10
        }
        Console.WriteLine();

        var subList = new List<int>() {7, 8};
        numbers.AddRange(subList);

        numbers.Sort();
        Console.WriteLine(numbers.BinarySearch(1)); // 0
        Console.WriteLine(numbers.BinarySearch(3)); // 1
        Console.WriteLine(numbers.BinarySearch(9)); // 8

        Console.WriteLine(numbers.Contains(2)); // false
        Console.WriteLine(numbers.Contains(1)); // true
        numbers.Clear();

        numbers.Insert(0, 9);
        numbers.InsertRange(1, subList);
        numbers.ForEach(number => Console.Write(number + " ")); // 9 7 8
        Console.WriteLine();

        bool areNumbersLessThan10 = numbers.TrueForAll(x => x < 10);
        Console.WriteLine(areNumbersLessThan10); // true

        numbers.Reverse();
        numbers.ForEach(number => Console.Write(number + " ")); // 8 7 9
        Console.WriteLine();

        Console.WriteLine(numbers.IndexOf(7)); // 1, index for last occurrence of 1
        Console.WriteLine(numbers.FindLast(x => x < 9)); // 7

        int[] arrayOfNumbers = numbers.ToArray();
    }
}

class Stacks : IExample {
    // Operate LIFO
    // Push, Pop, Peek, Clear,
    public void Run() {
        Stack<string> s = new Stack<string>();
        s.Push("a");
        s.Push("b");
        Console.WriteLine(s.Count); // 2
        foreach(string item in s) {
            Console.Write(item + " "); // b a
        }
        Console.WriteLine();

        Console.WriteLine(IsBalanced("([])")); // true
        Console.WriteLine(IsBalanced("([]"));  // false
    }

    private static bool IsBalanced(string inputString) {
        Stack<char> stackOfClosingBraces = new Stack<char>();
        Stack<char> stackOfOpeningBraces = new Stack<char>();

        foreach(char c in inputString) {
            if (c == '}' || c == ']' || c == ')') {
                stackOfClosingBraces.Push(c);
            }
        }

        for(int i=inputString.Length -1; i >= 0; i--) {
            char c = inputString[i];
            if (c == '{' || c == '[' || c == '(') {
                stackOfOpeningBraces.Push(c);
            }
        }

        if(stackOfOpeningBraces.Count != stackOfClosingBraces.Count) {
            return false;
        }

        while(stackOfClosingBraces.Count != 0) {
            char currentOpeningBrace = stackOfOpeningBraces.Pop();
            char currentClosingBrace = stackOfClosingBraces.Pop();
            if ((currentOpeningBrace == '{' && currentClosingBrace == '}') ||
                (currentOpeningBrace == '[' && currentClosingBrace == ']') ||
                (currentOpeningBrace == '(' && currentClosingBrace == ')')) {
                    continue;
            }
            return false;
        }
        return true;
    }
}

class Queues : IExample {
    // FIFO - First In First Out
    public void Run() {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("a");
        queue.Enqueue("b");
        queue.Enqueue("c");
        foreach(string item in queue) {
            Console.Write(item + " "); // a b c
        }
        Console.WriteLine();

        Console.WriteLine(queue.Dequeue()); // 'a'
        Console.WriteLine(queue.Peek());    // 'b'
    }
}

class Structs : IExample {
    struct Coordinate {
        public readonly int x;
        public readonly int y;

        public Coordinate(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() {
            return x.ToString() + ":" + y.ToString();
        }
    }

    public void Run() {
        var s = new Coordinate(1, 2);
        Console.WriteLine(s); // '1:2'
    }
}

class Enums : IExample {
    enum Weekday { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    public void Run() {
        var wd = Weekday.Monday;
        Console.WriteLine(wd); // Monday

        // get the names
        foreach(string s in Enum.GetNames(typeof(Weekday))) {
            Console.WriteLine(s);
        }

        Console.WriteLine("-----");
        // get the values
        foreach(int i in Enum.GetValues(typeof(Weekday))) {
            Console.WriteLine(i);
        }
    }
}

class Dictionaries : IExample {
    public void Run() {
        var dictionary = new Dictionary<string, string>();
        dictionary.Add("Key1", "Value1");
        dictionary.Add("Key2", "Value2");
        dictionary.Add("Key3", "Value3");

        Console.WriteLine(dictionary.Count); // 3

        foreach(string key in dictionary.Keys) {
            Console.WriteLine(key + ": " + dictionary[key]);
        }

        foreach(string value in dictionary.Values) {
            Console.WriteLine(value);
        }

        // otherwise we get Unhandled Exception:
        // System.ArgumentException: An item with the same key has already been added
        if (!dictionary.ContainsKey("Key1")) {
            dictionary.Add("Key1", "Value1");
        }

        if (dictionary.ContainsKey("Key1")) {
            dictionary.Remove("Key1");
        }

        // we can try this in one line
        string s = "";
        dictionary.TryGetValue("Key2", out s);
        Console.WriteLine(s); // 'Value2'

        foreach(KeyValuePair<string, string> entry in dictionary) {
            Console.WriteLine(entry.Key + ": " + entry.Value);
        }
        dictionary.Clear();
    }
}

class HashSets : IExample {
    public void Run() {
        // UnionWith
        var letters1 = new HashSet<string>() { "a", "b", "c" };
        var letters2 = new HashSet<string>() { "a", "b", "d", "e", "f" };

        letters1.UnionWith(letters2);
        foreach(string s in letters1) {
            Console.Write(s + " "); // a b c d e f 
        }
        Console.WriteLine();

        // IntersectWith
        letters1 = new HashSet<string>() { "a", "b", "c" };
        letters2 = new HashSet<string>() { "a", "b", "d", "e", "f" };

        letters1.IntersectWith(letters2);
        foreach(string s in letters1) {
            Console.Write(s + " "); // a b
        }
        Console.WriteLine();

        // ExceptWith
        letters1 = new HashSet<string>() { "a", "b", "c" };
        letters2 = new HashSet<string>() { "a", "b", "d", "e", "f" };

        letters1.ExceptWith(letters2);
        foreach(string s in letters1) {
            Console.Write(s + " "); // c
        }
        Console.WriteLine();

        // SymmetricExceptWith
        letters1 = new HashSet<string>() { "a", "b", "c" };
        letters2 = new HashSet<string>() { "a", "b", "d", "e", "f" };

        letters1.SymmetricExceptWith(letters2);
        foreach(string s in letters1) {
            Console.Write(s + " "); // e d c f
        }
        Console.WriteLine();
    }
}

class SortedLists : IExample {
    public void Run() {
        var slist = new SortedList<string, int>() { {"key1", 1}, {"key2", 2}, {"key3", 3} };
        Console.WriteLine(slist.Count); // 3

        foreach(KeyValuePair<string, int> entry in slist) {
            Console.WriteLine(entry.Key + ": " + entry.Value);
        }
        Console.WriteLine("-----");

        slist.Add("key4", 4);
        slist.Add("a", 7);
        foreach(KeyValuePair<string, int> entry in slist) {
            Console.WriteLine(entry.Key + ": " + entry.Value);
        }

        slist.Remove("key1"); // don't need to check that it exists
        slist.RemoveAt(0);
        Console.WriteLine(slist.ContainsKey("key2")); // true
        Console.WriteLine(slist.ContainsValue(2));    // true
        Console.WriteLine(slist.IndexOfKey("key3"));  // 1
        Console.WriteLine(slist.IndexOfValue(3));     // 1
        slist.Clear();
    }
}

class SortedDictionaries : IExample {
    /*
    Sorted list uses less memory
    Sorted dictionary has faster insertion and removal for unsorted data
    Sorted list is faster if the list is populated all at once with sorted data
    */
    public void Run() {
        var sdict = new SortedDictionary<string, string>() {
            { "key1", "value1" },
            { "key2", "value2" },
            { "key3", "value3" }
        };

        sdict.Add("key4", "value4");
        Console.WriteLine(sdict.Count);
        Console.WriteLine(sdict.Keys);
        Console.WriteLine(sdict.Values);
        Console.WriteLine(sdict.ContainsKey("key1")); // true
        Console.WriteLine(sdict.ContainsValue("value2")); // true
        foreach(KeyValuePair<string, string> entry in sdict) {
            Console.WriteLine(entry.Key + ": " + entry.Value);
        }

        string s = string.Empty;
        sdict.TryGetValue("key1", out s);
        Console.WriteLine(s); // value1
        sdict.Clear();
    }
}

class SortedSets : IExample {
    public void Run() {
        var s = new SortedSet<int>();
        s.Add(2);
        s.Add(1);
        s.Add(1);
        s.Add(3);
        s.Add(4);
        s.Remove(4);
        foreach(int i in s) {
            Console.Write(i + " "); // 1 2 3
        }
        Console.WriteLine();

        Console.WriteLine(s.Contains(1)); // true
        if (s.IsSubsetOf(new List<int>() {1, 2, 3} )) {
            Console.WriteLine("it is a subset");
        }

        if (s.IsSupersetOf(new List<int>() {1, 2} )) {
            Console.WriteLine("it is a superset");
        }

        s.RemoveWhere(x => x > 2);
        foreach(int i in s) {
            Console.Write(i + " "); // 1 2
        }
        Console.WriteLine();

        Console.WriteLine(s.Reverse());

        var list = new List<int>() { 6, 7, 8 };
        s.UnionWith(list); // also ExceptWith and SymmetricExceptWith
        foreach(int i in s) {
            Console.Write(i + " "); // 1 2 6 7 8
        }
        Console.WriteLine();

        Console.WriteLine(s.Min); // 1
        Console.WriteLine(s.Max); // 8
        s.Clear();
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new Arrays(),
            new Lists(),
            new Stacks(),
            new Queues(),
            new Structs(),
            new Enums(),
            new Dictionaries(),
            new HashSets(),
            new SortedLists(),
            new SortedDictionaries(),
            new SortedSets()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}