// csc namespaces.cs && namespaces && del namespaces.exe
// gives the compiler context for the different classes in a project
// reduces the possibility of naming conflicts
using System;
using System.Collections.Generic;
using ns3 = myLongNamespaceName;

interface IExample {
    void Run();
}

namespace ns1 {
    class MyClass { }
}

namespace ns2 {
    class MyClass { }
}

namespace myLongNamespaceName {
    class MyClass { }
}


class BasicNamespaces : IExample {
    public void Run() {
        var o1 = new ns1.MyClass();
        var o2 = new ns2.MyClass();
        Console.WriteLine(o1);
        Console.WriteLine(o2);
    }
}

class Aliases : IExample {
    // aliases are how you shorthand reference a namespace
    public void Run() {
        var o1 = new ns3.MyClass();                 // so we can do this
        var o2 = new myLongNamespaceName.MyClass(); // instead of this

    }
}

namespace name1 {
    namespace name2 {
        namespace name3 {
            class MyClass { }
        }
    }
}

class TheDotOperator : IExample {
    public void Run() {
        var obj = new name1.name2.name3.MyClass();
        Console.WriteLine(obj);
    }
}

class TheNamespaceAliasQualifier : IExample { // '::'
    public void Run() {
        global::System.Console.WriteLine("hi there");
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new BasicNamespaces(),
            new Aliases(),
            new TheDotOperator(),
            new TheNamespaceAliasQualifier()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}