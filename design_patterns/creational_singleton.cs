// csc creational_singleton.cs && creational_singleton && del creational_singleton.exe
using System;

class MyClass {}


class Singleton {
    static MyClass instance = new MyClass();

    public MyClass GetInstance() {
        return instance;
    }
}


class Program {
    public static void Main() {
        var obj1 = new Singleton().GetInstance();
        var obj2 = new Singleton().GetInstance();
        var obj3 = new MyClass();

        Console.WriteLine(obj1 == obj2); // True
        Console.WriteLine(obj2 == obj3); // False
    }
}
