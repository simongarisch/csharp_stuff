// csc delegates.cs && delegates && del delegates.exe
// A delegate is a reference type variable that holds the reference to a method.
// The reference can be changed at runtime.
using System;


delegate int Operation(int n);

class Program {
    static int num = 10;

    public static int Add(int n) {
        num += n;
        return num;
    }

    public static int Sub(int n) {
        num -= n;
        return num;
    }

    public static void Main() {
        Operation add = new Operation(Add);
        Operation sub = new Operation(Sub);

        add(2);
        sub(4);
        Console.WriteLine(num); // 8
    }
}
