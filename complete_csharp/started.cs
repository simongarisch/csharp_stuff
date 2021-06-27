// csc started.cs && started && del started.exe
using System;
using System.Collections.Generic;

interface Example {
    void Run();
}


class HelloWorld : Example {
    public void Run() {
        Console.WriteLine("Hello, World!");
    }
}

class Variables : Example {
    public void Run() {
        int i = 3;
        float f = 7.77f;
        double d = 7.78;
        string s = "this is a string";
        char c = 'x';
        bool b = true;

        var items = new List<Object> {i, f, d, s, c , b};
        foreach(var item in items) {
            Console.WriteLine(item.GetType().Name + " of value " + item);
        }
    }
}

class ConditionalStatements : Example {
    public void Run() {
        var complete = false;
        var started = true;
        int x;

        if (complete) {
            x = 5;
        } else if (started) {
            x = 3;
        } else {
            x = 1;
        }

        Console.WriteLine(x);
    }
}

class Loops : Example {
    public void Run() {
        for(int i=1; i<=5; i++) {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        int x = 5;
        while (x > 0) {
            Console.Write(x + " ");
            x--;
        }
        Console.WriteLine();

        int[] items = {1, 2, 3, 4, 5};
        foreach(var item in items) {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

class Comments : Example {
    public void Run() {
        // nothing to see here.

        /*
        Or here...
        */

        // there are also XML documentation comments
        ///<summary>
        ///This is an XML documentation comment
        ///</summary>
    }
}

class Functions : Example {
    public void Run() {
        PrintHi();

        Func<double, double> cube = x => x * x * x;
        Console.WriteLine(cube(2));
    }

    static void PrintHi() {
        Console.WriteLine("Hi");
    }
}

class Errors : Example {
    public void Run() {
        // types of errors - syntax error, logic error, runtime error
        int x = 7;
        int y = 0;
        try {
            var z = x / y; // zero division error...
        } catch (System.DivideByZeroException e) {
            Console.WriteLine(e.ToString());
        } finally {
            Console.WriteLine("cleanup not needed in this case");
        }
    }
}

class Modulus : Example {
    public void Run() {
        int x = 5 % 4;
        Console.WriteLine(x); // 1
    }
}

class IncrementAndDecrement : Example {
    public void Run() {
        int x = 7;
        x++;
        Console.WriteLine(x); // 8
        x--;
        Console.WriteLine(x); // 7
    }
}

class IsOperator : Example {
    class C1 {}
    class C2 : C1 {}

    C1 c1 = new C1();
    C2 c2 = new C2();

    public void Run() {
        Console.WriteLine(1 is int);        // true
        Console.WriteLine(1 is double);     // false
        Console.WriteLine("abc" is string); // true

        Console.WriteLine(c2 is C1); // true, C2 is a subclass of C1
        Console.WriteLine(c1 is C2); // false
        Console.WriteLine(c1 is Object); // true, all objects subclass from Object
    }
}

class AsOperator : Example {
    public void Run() {
        object so = "abc";
        string s = so as string;
        Console.WriteLine(s); // 'abc'
    }
}

class TernaryOperator : Example {
    public void Run() {
        int x = 7;
        int value = 8;
        bool isGreater = x > value ? true : false;
        Console.WriteLine(isGreater); // false
    }
}

class NullCoalescingOperator : Example {
    public void Run() {
        object obj = null;
        object obj2 = obj ?? new object();
        Console.WriteLine(obj == null);  // true 
        Console.WriteLine(obj2);         // System.Object
    }
}

class SizeOfOperator : Example {
    public void Run() {
        // used to obtain the size, in bytes, of compile time known resources
        // reveals how many bytes of memory each type takes up
        // takes in a type and returns an int
        Console.WriteLine(sizeof(int));    // 4
        Console.WriteLine(sizeof(double)); // 8
        Console.WriteLine(sizeof(bool));   // 1
    }
}

class TypeOfOperator : Example {
    class C1 {}

    public void Run() {
        Console.WriteLine(typeof(int));    // System.Int32
        Console.WriteLine(typeof(double)); // System.Double
        Console.WriteLine(typeof(C1));     // TypeOfOperator+C1
    }
}

class OperatorOverloading : Example {
    class Box {
        private int length;
        private int width;
        private int height;

        public Box(int length, int width, int height) {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public int GetLength() {
            return length;
        }

        public int GetWidth() {
            return width;
        }

        public int GetHeight() {
            return height;
        }

        public static Box operator +(Box box1, Box box2) {
            return new Box(
                box1.GetLength() + box2.GetLength(),
                box1.GetWidth() + box2.GetWidth(),
                box1.GetHeight() + box2.GetHeight()
            );
        }
    }

    public void Run() {
        Box box1 = new Box(2, 2, 2);
        Box box2 = new Box(2, 2, 2);
        Box box3 = box1 + box2;
        Console.WriteLine(box3.GetLength() + " " + box3.GetWidth() + " " + box3.GetHeight()); // 4 4 4
    }
}

class Program {
    public static void Main() {
        var examples = new List<Example> {
            new HelloWorld(),
            new Variables(),
            new ConditionalStatements(),
            new Loops(),
            new Comments(),
            new Functions(),
            new Errors(),
            new Modulus(),
            new IncrementAndDecrement(),
            new IsOperator(),
            new AsOperator(),
            new TernaryOperator(),
            new NullCoalescingOperator(),
            new SizeOfOperator(),
            new TypeOfOperator(),
            new OperatorOverloading()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("-------");
        }
    }
}
