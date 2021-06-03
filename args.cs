// csc args.cs && args 1 2 three && del args.exe
using System;


class Program {
    public static void Main(string[] args) {
        foreach(string arg in args) {
            Console.Write(arg + ","); // 1,2,three,
        }
        Console.WriteLine();
        
        Console.WriteLine(args.Length); // 3
    }
}