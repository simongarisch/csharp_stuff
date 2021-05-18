// csc virtual.cs && virtual && del virtual.exe
/*
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
The virtual keyword is used to modify a method, property, indexer,
or event declaration and allow for it to be overridden in a derived class.
By default, methods are non-virtual. You cannot override a non-virtual method.
 */
using System;


class Base {
    public virtual void vmethod() {
        Console.WriteLine("Base class virtual method");
    }

    public void method() {}
}


class Derived : Base {
    public override void vmethod() {
        Console.WriteLine("Derived class overridden method");
    }

    // public override void method {} // can't be done... compile error
}


class Program {
    public static void Main() {
        var b = new Base();
        var d = new Derived();

        b.vmethod(); // Base class virtual method
        d.vmethod(); // Derived class overridden method
    }
}
