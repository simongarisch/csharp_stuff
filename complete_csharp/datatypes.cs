// csc datatypes.cs && datatypes && del datatypes.exe
using System;
using System.Collections.Generic;

interface Example {
    void Run();
}

class BasicDataTypes : Example {
    public void Run() {
        /*
        built in types are e.g.:
        int
        float
        string
        char
        bool
        */

        bool b = true;
        float f = 10.7f;
        int i = 7;
        string s = "this is a string";
        char c = 'c';

        var objects = new List<object> {b, f, i, s, c};
        foreach(var item in objects) {
            Console.WriteLine(item + " -> " + item.GetType().Name);
        }
        /*
        True -> Boolean
        10.7 -> Single
        7 -> Int32
        this is a string -> String
        c -> Char
        */

        Console.WriteLine("==========");
        Console.WriteLine(typeof(bool));   // System.Boolean
        Console.WriteLine(typeof(float));  // System.Single
        Console.WriteLine(typeof(int));    // System.Int32
        Console.WriteLine(typeof(string)); // System.String
        Console.WriteLine(typeof(char));   // System.Char
    }
}

class FloatingPointPrecision : Example {
    public void Run() {
        float f = 5.6f;
        int x = (int)f;
        Console.WriteLine(x); // 5
    }
}

class MathClass : Example {
    public void Run() {
        Console.WriteLine(System.Math.Abs(-3)); // 3
        Console.WriteLine(Math.Round(3.7f));    // 4
        Console.WriteLine(Math.Ceiling(5.2f));  // 6
        Console.WriteLine(Math.Floor(5.7f));    // 5
        Console.WriteLine(Math.Min(7, 10));     // 7
        Console.WriteLine(Math.Max(7, 10));     // 10
    }
}

class Strings : Example {
    public void Run() {
        string emptyString = "";
        string emptyString2 = string.Empty;

        // strings are immutable
        string s1 = "hi";
        string s2 = "there";
        string s3 = s1 + " " + s2;
        Console.WriteLine(s3); // 'hi there'

        // characters
        char char1 = 'a';
        char char2 = '\n';
        string s4 = "abc";
        System.Char[] s5 = new System.Char[] {'a', 'b', 'c'};

        // checking for string equality
        s1 = "xxx";
        s2 = "xxx";
        Console.WriteLine(s1 == s2); // true
        Console.WriteLine(Strings.Equals(s1, s2)); // true

        // substrings
        String example = "abc";
        Console.WriteLine(example.Contains("bc")); // true
        Console.WriteLine(example.Substring(1));   // 'bc'
        Console.WriteLine(example.Substring(0,2)); // 'ab'

        // escape sequences
        Console.WriteLine("we can use these for \" quotes or \\ backslashes"); // we can use these for " quotes or \ backslashes
        // Console.WriteLine("\a"); // plays a beep on the computer...
        Console.WriteLine("Tabby \t McTabTab");

        // string formatting
        int price = 100;
        Console.WriteLine("The item costs {0:C}", price); // The item costs $100.00

        int price1 = 100;
        int price2 = 200;
        int price3 = 300;
        Console.WriteLine("Prices are {0:C}, {1:C}, {2:C}", price1, price2, price3); // Prices are $100.00, $200.00, $300.00

        float percent = 0.4f;
        Console.WriteLine("The task is {0:P} complete", percent); // The task is 40.00% complete

        // the StringBuilder class
        var stringBuilder = new System.Text.StringBuilder();
        stringBuilder.Append("Hello World");
        for (int i=0; i<4; i++) {
            stringBuilder.Append("blah");
        }

        string s = stringBuilder.ToString();
        Console.WriteLine(s); // Hello Worldblahblahblahblah

        stringBuilder.Clear();
        Console.WriteLine(stringBuilder.ToString().Length); // 0
        stringBuilder.AppendLine("This is a new line");
        stringBuilder.AppendLine("And this is another...");
        Console.WriteLine(stringBuilder.ToString());

        var sb = new System.Text.StringBuilder("Hello World");
        sb.Remove(6, 5); // startIndex, length to remove 'World'
        Console.WriteLine(sb.ToString()); // 'Hello'

        var sb2 = new System.Text.StringBuilder("This is a string with some spaces");
        sb2.Replace(" ", "_");
        Console.WriteLine(sb2.ToString()); // This_is_a_string_with_some_spaces

        s = "abc";
        Console.WriteLine(s.IndexOf("b")); // 1
        Console.WriteLine(s.ToUpper());    // 'ABC'
        Console.WriteLine(s.ToLower());    // 'abc'

        s = s.Insert(1, "_ins_"); // insert at index 1
        Console.WriteLine(s);     // 'a_ins_bc'
        s = s.Remove(3);          // remove characters starting from index 3
        Console.WriteLine(s);     // 'a_i'

        s = " blah ";
        Console.WriteLine(s.Trim(' ')); // 'blah'

        s = "abc";
        Console.WriteLine(s.Replace("bc", "**")); // 'a**'

        // splitting strings
        s = "the quick brown fox jumped over the lazy dog";
        string[] sArray = s.Split(' ');
        foreach(var item in sArray) {
            Console.Write("*" + item + "*"); // *the**quick**brown**fox**jumped**over**the**lazy**dog*
        }
        Console.WriteLine();

        // null or empty strings
        s = null;
        Console.WriteLine(string.IsNullOrEmpty(s)); // true
        s = "";
        Console.WriteLine(string.IsNullOrEmpty(s)); // true
        s = "sss";
        Console.WriteLine(string.IsNullOrEmpty(s)); // false
    }
}

class Booleans : Example {
    public void Run() {
        bool b = false;
        Console.WriteLine(b);               // false
        Console.WriteLine(b.GetType());     // System.Boolean
        Console.WriteLine(b.GetTypeCode()); // Boolean
    }
}

class LogicalOperators : Example {
    public void Run() {
        bool completed = false;
        Console.WriteLine(!completed);   // true

        Console.WriteLine(true & true);  // true
        Console.WriteLine(true & false); // false

        Console.WriteLine(true | true);   // true
        Console.WriteLine(true | false);  // true
        Console.WriteLine(false | false); // false

        // short circuit operators
        // there may be no need to evaluate the second item if we know the first is true / false
        Console.WriteLine(true && true);  // true
        Console.WriteLine(true && false); // false

        Console.WriteLine(true || true);   // true
        Console.WriteLine(true || false);  // true
        Console.WriteLine(false || false); // false
    }
}

class WorkingWithNull : Example {
    public void Run() {
        object o = null;
        bool? example = null; // nullable boolean
        Console.WriteLine(example == null); // true

        // we can make other values nullable too
        int? example2 = null;
        char? example3 = null;
        Console.WriteLine(example2 == null); // true
        Console.WriteLine(example3 == null); // true
    }
}

class BoxingAndUnboxing : Example {
    public void Run() {
        int num = 3;
        float f = num; // implicit conversion
        Console.WriteLine(f + " " + f.GetType().Name); // 3 Single

        f = 7.3f;
        int x = (int)f; // explicit conversion
        Console.WriteLine(x + " " + x.GetType().Name); // 7 Int32

        // boxing and unboxing
        // computationally expensive to box and unbox
        int example = 1;
        object o = example;
        int example2 = (int)o;
        Console.WriteLine(example2); // 1
    }
}

class AnonymousAndDynamicTypes : Example {
    public void Run() {
        // https://www.geeksforgeeks.org/difference-between-var-and-dynamic-in-c-sharp/
        // https://stackoverflow.com/questions/2690623/what-is-the-dynamic-type-in-c-sharp-4-0-used-for
        var example1 = 1;      // implicitly typed variable at compile time
        dynamic example2 = 2;  // type is checked at run time (rather than compile time)
    }
}

class ValueAndReferenceTypes : Example {

    public class MyInt {
        public int x;
        public MyInt(int x) {
            this.x = x;
        }
    }

    public void Run() {
        // Every value type in C# holds it's own value in memory and derives from System.ValueType.
        // This includes Bool, Byte, Char, Decimal, Double, Enum, Float, Int...
        // Everything else is a reference type.

        // value types will be passed by value (and not by reference)
        int x = 1;
        Console.WriteLine("Before: " + x);  // 1
        ChangeInt(x);
        Console.WriteLine("After: " + x);   // 1 (still, did not change...)
        Console.WriteLine("===========");

        // reference types contain a pointer to an address in memory
        // reference types will be passed by reference
        var myInt = new MyInt(1);
        Console.WriteLine("Before: " + myInt.x); // 1
        ChangeMyInt(myInt);
        Console.WriteLine("After: " + myInt.x);  // 7
    }

    static void ChangeInt(int x) {
        x = 7;
    }

    static void ChangeMyInt(MyInt myInt) {
        myInt.x = 7;
    }
}

class Program {
    public static void Main() {
        var examples = new List<Example> {
            new BasicDataTypes(),
            new FloatingPointPrecision(),
            new MathClass(),
            new Strings(),
            new Booleans(),
            new LogicalOperators(),
            new WorkingWithNull(),
            new BoxingAndUnboxing(),
            new AnonymousAndDynamicTypes(),
            new ValueAndReferenceTypes()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example " + example.GetType().Name + " ...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
