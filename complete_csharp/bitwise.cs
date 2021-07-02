// csc bitwise.cs && bitwise && del bitwise.exe
using System;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class ComplimentOperator : IExample {
    public void Run() {
        int byteOfData = 13; // 00001101

        // base 2 for binary
        Console.WriteLine(Convert.ToString(byteOfData, 2)); // 1101

        // general rule: add one to the number and put a -'ve sign in front of it
        Console.WriteLine(~byteOfData); // -14
        Console.WriteLine(Convert.ToString(~byteOfData, 2).Substring(24, 8)); // 11110010
    }
}

class LeftShiftOperator : IExample {
    public void Run() {
        int i = 2; // 00000010

        // i left shifted by one bit
        Console.WriteLine(i << 1); // 00000100 or 4
        Console.WriteLine(i << 2); // 00001000 or 8
        Console.WriteLine(i << 3); // 00010000 or 16
        Console.WriteLine(i << 4); // 00100000 or 32
        Console.WriteLine(i << 5); // 01000000 or 64
        Console.WriteLine(i << 6); // 10000000 or 128
    }
}

class RightShiftOperator : IExample {
    public void Run() {
        int j = 128; // 10000000

        Console.WriteLine(j >> 1); // 01000000 or 64
        Console.WriteLine(j >> 2); // 00100000 or 32
        Console.WriteLine(j >> 3); // 00010000 or 16
        Console.WriteLine(j >> 4); // 00001000 or 8
        Console.WriteLine(j >> 5); // 00000100 or 4
        Console.WriteLine(j >> 6); // 00000010 or 2
        Console.WriteLine(j >> 7); // 00000001 or 1
    }
}

class BitwiseAndOperator : IExample {
    public void Run() {
        int i = 33;  // 00100001
        int j = 129; // 10000001
        // expecting -  00000001

        Console.WriteLine(i & j); // 1
    }
}

class BitwiseXorOperator : IExample {
    public void Run() {
        int i = 33;  // 00100001
        int j = 129; // 10000001
        // expecting -  10100000 or 160
        // XOR is only 1 when we have a 1 and a 0

        Console.WriteLine(i ^ j); // 160
    }
}

class BitwiseOrOperator : IExample {
    public void Run() {
        int i = 33;  // 00100001
        int j = 129; // 10000001
        // expecting -  10100001

        Console.WriteLine(i | j); // 10100001 or 161
    }
}

class CompoundAssignment : IExample {
    public void Run() {
        int a = 2;
        a <<= 2;              // shift by 2 bits
        Console.WriteLine(a); // 8

        /* precedence is
           <<, >>   shift
           &        and
           ^        xor
           |        or
        */
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new ComplimentOperator(),
            new LeftShiftOperator(),
            new RightShiftOperator(),
            new BitwiseAndOperator(),
            new BitwiseXorOperator(),
            new BitwiseOrOperator(),
            new CompoundAssignment()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}