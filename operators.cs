// csc operators.cs && operators && del operators.exe
// https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debug.assert?view=net-5.0
using System;
using System.Diagnostics;


class Num {
    public readonly int x;
 
    public Num(int x) {
        this.x = x;
    }

    public static Num operator+ (Num left, Num right) {
        return new Num(left.x + right.x);
    }
    
    public static Num operator- (Num left, Num right) {
        return new Num(left.x - right.x);
    }
    
    public static bool operator> (Num left, Num right) {
        return left.x > right.x;
    }
    
    public static bool operator< (Num left, Num right) {
        return left.x < right.x;
    }

    public static bool operator>= (Num left, Num right) {
        return left.x >= right.x;
    }

    public static bool operator<= (Num left, Num right) {
        return left.x <= right.x;
    }
}


class Program {
    public static void Main() {
        var x = new Num(2);
        var y = new Num(3);

        var resultAdd = x + y;
        var resultSub = x - y;
        Console.WriteLine(resultAdd + ": " + resultAdd.x); // Num:  5
        Console.WriteLine(resultSub + ": " + resultSub.x); // Num: -1
        Console.WriteLine(x > y); // False
        Console.WriteLine(x < y); // True
    }
}
