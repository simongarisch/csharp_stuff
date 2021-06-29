// csc interfaces.cs && interfaces && del interfaces.exe
// dotnet-script interfaces.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel; // INotifyPropertyChanged

interface IExample {
    void Run();
}

class Interfaces : IExample {
    interface ITalk {
        void Talk();
    }

    class C1 : ITalk  {
        public void Talk() {
            Console.WriteLine("blah blah");
        }
    }

    class C2 : ITalk {
        public void Talk() {
            Console.WriteLine("blah blah blah blah");
        }
    }

    public void Run() {
        ITalk c1 = new C1();
        ITalk c2 = new C2();
        c1.Talk(); // 'blah blah'
        c2.Talk(); // 'blah blah blah blah'
    }
}

class MyClass : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    private string name;
    public string Name {
        get { return name; }
        set {
            name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public MyClass(string name) {
        this.name = name;
    }
}

class NotifyPropertyChangedExample : IExample {
    public void Run() {
        var m = new MyClass("bobby");
        m.Name = "Sam";
        Console.WriteLine(m.Name); // 'Sam'
    }
}

class Employee : IComparable<Employee>, IExample {
    // https://zetcode.com/csharp/icomparable/
    // The interface requires the CompareTo method to be implemented.
    // The implemented method is automatically called by methods such
    // as Array.Sort and ArrayList.Sort.
    public readonly string Name;
    public int Salary;

    public Employee(string Name, int Salary) {
        this.Name = Name;
        this.Salary = Salary;
    }

    public override string ToString() {
        return this.Name + ", " + this.Salary.ToString();
    }

    public int CompareTo(Employee other) {
        if (this.Salary < other.Salary) {
            return +1;
        } else if (this.Salary > other.Salary) {
            return -1;
        }
        return 0;
    }

    public void Run() {
        var employees = new List<Employee> {
            new Employee("John Doe", 1230),
            new Employee("Lucy Novak", 670),
            new Employee("Robin Brown",2300),
            new Employee("Joe Draker", 1190),
            new Employee("Janet Doe", 980)
        };

        employees.Sort();
        employees.ForEach(employee => Console.WriteLine(employee));
    }
}

public class Person : IExample {
    // https://www.c-sharpcorner.com/UploadFile/80ae1e/icomparable-icomparer-and-iequatable-interfaces-in-C-Sharp/
    public readonly string Name;
    public int Age;

    public Person(string Name, int Age) {
        this.Name = Name;
        this.Age = Age;
    }

    public override string ToString() {
        return this.Name + ": " + this.Age.ToString();
    }

    public void Run() {
        var people = new Person[] {
            new Person("Dave", 21),
            new Person("Anne", 74),
            new Person("Simon", 36),
            new Person("James", 7)
        };

        var personComparer = new PersonComparer();

        Console.WriteLine("Sort by name...");
        personComparer.compareField = SortBy.Name;
        Array.Sort(people, personComparer);
        foreach(var person in people) {
            Console.WriteLine(person);
        }
        
        Console.WriteLine("Sort by age...");
        personComparer.compareField = SortBy.Age;
        Array.Sort(people, personComparer);
        foreach(var person in people) {
            Console.WriteLine(person);
        }
    }
}

public enum SortBy {
    Name,
    Age
}

public class PersonComparer : IComparer<Person> {
    // With the IComparer interface we can separate the comparing logic into a separate class.
    // The Compare method then has two args (rather than in CompareTo for IComparable). 
    public SortBy compareField = SortBy.Name;

    public int Compare(Person x, Person y) {
        switch (compareField) {
            case SortBy.Name:
                return x.Name.CompareTo(y.Name);
                break;
            case SortBy.Age:
                return x.Age.CompareTo(y.Age);
                break;
            default:
                break;
        }

        return x.Name.CompareTo(y.Name);
    }
}

class IEquatableExample : IEquatable<IEquatableExample>, IExample {
    // IEquatable requires an Equals method.
    int x;

    public IEquatableExample(int x) {
        this.x = x;
    }

    public bool Equals(IEquatableExample other) {
        if (other == null) {
            return false;
        }
        return this.x == other.x;
    }

    public void Run() {
        var ex1 = new IEquatableExample(1);
        var ex2 = new IEquatableExample(2);
        var ex3 = new IEquatableExample(3);
        var ex4 = new IEquatableExample(1);

        // this can be used with the contains method
        var examples = new List<IEquatableExample> {ex1, ex2};
        Console.WriteLine(examples.Contains(ex3)); // false
        Console.WriteLine(examples.Contains(ex4)); // true
    }
}

class Money {
    public int amount;
}

class Wallet : IEnumerable, IExample {
    // in order to call foreach IEnumerable must be implemented under the hood.
    Money[] bills = null;
    int openIndex = 0;

    public Wallet() {
        bills = new Money[100];
    }

    public void Add(Money bill) {
        bills[openIndex] = bill;
        openIndex++;
    }

    public IEnumerator GetEnumerator() {
        foreach(var bill in bills) {
            if (bill == null) {
                break;
            }
            yield return bill;
        }
    }

    public void Run() {
        var wallet = new Wallet();
        wallet.Add(new Money() { amount = 1});
        wallet.Add(new Money() { amount = 5});
        wallet.Add(new Money() { amount = 10});
        wallet.Add(new Money() { amount = 20});
        wallet.Add(new Money() { amount = 50});
        wallet.Add(new Money() { amount = 100});

        foreach(Money money in wallet) {
            Console.WriteLine("Bill: " + money.amount);
        }
    }
}

abstract class Animal {
    public abstract void Talk();
}

class Dog : Animal, IExample {
    public override void Talk() {
        Console.WriteLine("Woof");
    }

    public void Run() {
        Talk(); // 'Woof'
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new Interfaces(),
            new NotifyPropertyChangedExample(),
            new Employee("John", 1000),
            new Person("James", 27),
            new IEquatableExample(7),
            new Wallet(),
            new Dog()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}

Program.Main();