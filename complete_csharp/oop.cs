/*
csc oop.cs && oop && del oop.exe

Encapsulation means data hiding
Abstraction is hiding the details of how things work
Inheritance means that one class can share data and functions with another class
Polymorphism means classes can share data and functions but have different functionality
*/
using System;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class BasicObjects : IExample {
    class Car {
        string make;
        string model;

        public Car(string make, string model) {
            this.make = make;
            this.model = model;
        }

        public void Drive() {
            Console.WriteLine(this.make + " " + this.model + " is driving");
        }
    }

    public void Run() {
        var car = new Car("Ford", "Mustang");
        car.Drive(); // Ford Mustang is driving
    }
}

class Encapsulation : IExample {
    // you can do this by making smart choices with access modifiers
    private static int number1 = 3;
    private static int number2 = 5;

    public static int MultiplyWithExtras(int num1, int num2) {
        return num1 * num2 + number1 + number2; 
    }

    public void Run() {
        Console.WriteLine(MultiplyWithExtras(2, 3)); // 14
    }
}

class Abstraction : IExample {
    // interfaces and abstract classes are based on abstraction
    abstract class MyAbstract {
        public abstract int MyMethod();
    }

    class Concrete : MyAbstract {
        public override int MyMethod() {
            return 42;
        }
    }
    public void Run() {
        var concrete = new Concrete();
        Console.WriteLine(concrete.MyMethod()); // 42
    }
}

class Inheritance : IExample {
    // note that we can't inherit from a sealed class

    abstract class Animal {
        public void Pinch() {
            Console.WriteLine("Initiate pain sequence");
        }

        public abstract void Talk();
    }

    class Dog : Animal {
        public override void Talk() {
            Console.WriteLine("Woof de woof");
        }
    }

    class Cat : Animal {
        public override void Talk() {
            Console.WriteLine("Meow de meow");
        }
    }

    public void Run() {
        var dog = new Dog();
        var cat = new Cat();

        dog.Pinch(); // Initiate pain sequence
        cat.Pinch(); // Initiate pain sequence
        
        dog.Talk();  // Woof de woof
        cat.Talk();  // Meow de meow
    }
}

class Polymorphism : IExample {
    // poly means many, morphism means forms
    public class Class1 {
        public virtual void Example() {
            Console.WriteLine("Class 1's Example method");
        }
    }

    public class Class2 : Class1 {
        public override void Example() {
            Console.WriteLine("Class 2's Example method");
        }
    }

    public void Run() {
        var c1 = new Class1();
        var c2 = new Class2();

        c1.Example(); // Class 1's Example method
        c2.Example(); // Class 2's Example method
    }
}

class Covariance : IExample {
    // https://en.wikipedia.org/wiki/Covariance_and_contravariance_(computer_science)
    public class ExampleClass { }
    public class DerivedExampleClass : ExampleClass { }

    public static void ExampleMethod(ExampleClass ex) {
        Console.WriteLine("Received type: " + ex.GetType().Name);
    }

    public void Run() {
        var exampleClass = new ExampleClass();
        var derivedExampleClass = new DerivedExampleClass();
        ExampleMethod(exampleClass);        // Received type: ExampleClass
        ExampleMethod(derivedExampleClass); // Received type: DerivedExampleClass
    }
}

class PartialClasses : IExample {
    public partial class MyClass {
        public void Method1() {
            Console.WriteLine("Calling Method1");
        }
    }

    public partial class MyClass {
        public void Method2() {
            Console.WriteLine("Calling Method2");
        }
    }

    public void Run() {
        var c = new MyClass();
        c.Method1(); // Calling Method1
        c.Method2(); // Calling Method2
    }
}

class Indexers : IExample {
    private string[] dataArray = new string[100];

    public object this[int index] {
        get {
            if (index < 0 || index >= dataArray.Length) {
                Console.WriteLine("Invalid Index");
                return new object();
            } else {
                return dataArray[index];
            }
        }
        set {
            if (index < 0 || index >= dataArray.Length) {
                Console.WriteLine("Invalid Index");
            } else {
                dataArray[index] = value.ToString();
            }
        }
    }

    public void Run() {
        var indexers = new Indexers();
        indexers[0] = "Hi";
        indexers[1] = 2;
        indexers[2] = true;
        indexers[101] = 7; // Invalid Index

        Console.WriteLine(indexers[0]); // Hi
        Console.WriteLine(indexers[1]); // 2
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new BasicObjects(),
            new Encapsulation(),
            new Inheritance(),
            new Polymorphism(),
            new Covariance(),
            new PartialClasses(),
            new Indexers()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name);
            example.Run();
            Console.WriteLine("==========");
        }
    }
}