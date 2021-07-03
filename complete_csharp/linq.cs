// csc linq.cs && linq && del linq.exe
// dotnet-script linq.cs
// LINQ = Language Integrated Query, similar to SQL that lets us embed a query into C#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

interface IExample {
    void Run();
}

class BasicQuery : IExample {
    class Person {
        public string Name;
        public int Age;
    }

    public void Run() {
        var people = new List<Person>() {
            new Person() { Name = "John", Age = 30 },
            new Person() { Name = "Sarah", Age = 46 },
            new Person() { Name = "James", Age = 21 },
            new Person() { Name = "Joseph", Age = 24 },
        };

        int oldestPersonAge = people.Select(x => x.Age).Max();
        Console.WriteLine(oldestPersonAge); // 46
    }
}

class Cast : IExample {
    public void Run() {
        List<string> collection = new List<string>() { "1", "2", "3" };
        /*
        IEnumerable<int> collectionOfInts = collection.Cast<int>();
        foreach(var item in collectionOfInts) {
            Console.WriteLine(item.GetType().Name + ": " + item);
        }
        */
    }
}

class SelectAndSelectMany : IExample {
    public void Run() {
        var collection = new List<int>() { 1, 2, 3 };
        var collection2X = collection.Select(s => s * 2);
        foreach(var item in collection2X) {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // select many
        var collection2 = new List<List<int>>() {
            new List<int> { 1, 2, 3 },
            new List<int> { 4, 5, 6 },
            new List<int> { 7, 8, 9 }
        };

        // flattens the list of lists
        var result = collection2.SelectMany(list => list);
        foreach(var item in result) {
            Console.Write(item + " "); // 1 2 3 4 5 6 7 8 9
        }
        Console.WriteLine(string.Empty);
    }
}

class OfType_Where : IExample { // filters
    public void Run() {
        var collection = new ArrayList() { "a", 2, "b", 4, "c", 6 };
        var collectionOfStrings = collection.OfType<string>();
        foreach(var item in collectionOfStrings) {
            Console.Write(item + " "); // a b c
        }
        Console.WriteLine(string.Empty);

        var collection2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
        var collectionOfInts = collection2.Where(i => i > 3);
        foreach(var item in collectionOfInts) {
            Console.Write(item + " "); // 4 5 6
        }
        Console.WriteLine(string.Empty);
    }
}

class OrderBy_ThenBy_Reverse : IExample { // sorting
    class Person {
        public string Name;
        public int Age;

        public override string ToString() {
            return this.Name + ":" + this.Age;
        }
    }

    public void Run() {
        var people = new List<Person>() {
            new Person() { Name = "Zach"},
            new Person() { Name = "Robert"},
            new Person() { Name = "Albert" },
            new Person() { Name = "John" },
        };

        var ascendingNames = people.OrderBy(x => x.Name);
        var descendingNames = people.OrderByDescending(x => x.Name);
        foreach(var person in ascendingNames) {
            Console.Write(person.Name + " "); // Albert John Robert Zach
        }
        Console.WriteLine(string.Empty);
        foreach(var person in descendingNames) {
            Console.Write(person.Name + " "); // Zach Robert John Albert
        }
        Console.WriteLine(string.Empty);

        var people2 = new List<Person>() {
            new Person() { Name = "Zach", Age = 25},
            new Person() { Name = "Zach", Age = 30},
            new Person() { Name = "Zach", Age = 90},
            new Person() { Name = "Zach", Age = 5},
        };
        var sortedPeople = people2.OrderBy(x => x.Name).ThenByDescending(x => x.Age).Reverse();
        foreach(var person in sortedPeople) {
            Console.Write(person.ToString() + " "); // Zach:5 Zach:25 Zach:30 Zach:90
        }
        Console.WriteLine(string.Empty);
    }
}

class GroupBy : IExample {
    class Person {
        public readonly string FirstName;
        public readonly string LastName;

        public Person(string FirstName, string LastName) {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string ToString() {
            return this.FirstName + " " + this.LastName;
        }
    }

    public void Run() {
        var people = new List<Person>() {
            new Person("John", "Smith"),
            new Person("Sally", "Smith"),
            new Person("Thomas", "Gioia"),
            new Person("Robert", "Gioia")
        };

        var groupedPeople = people.GroupBy(person => person.LastName);
        foreach(var personGroup in groupedPeople) {
            Console.WriteLine("*** Key: " + personGroup.Key + " ***");
            foreach(var person in personGroup) {
                Console.Write(person + ", "); //
            }
            Console.WriteLine(string.Empty);
        }
        /* 
        *** Key: Smith ***
        John Smith, Sally Smith,
        *** Key: Gioia ***
        Thomas Gioia, Robert Gioia,
        */
    }
}

class DistinctExceptIntersectUnion : IExample {
    public void Run() {
        var collection1 = new List<int>() { 1, 1, 2, 3, 4, 5 };
        var collection2 = new List<int>() { 4, 5, 6, 7, 8};

        // Union
        var result = collection1.Union(collection2);
        foreach(var item in result) {
            Console.Write(item + " "); // 1 2 3 4 5 6 7 8 
        }
        Console.WriteLine(string.Empty);

        // Intersect
        var result2 = collection1.Intersect(collection2);
        foreach(var item in result2) {
            Console.Write(item + " "); // 4 5
        }
        Console.WriteLine(string.Empty);

        // Except
        var result3 = collection1.Except(collection2);
        foreach(var item in result3) {
            Console.Write(item + " "); // 1 2 3
        }
        Console.WriteLine(string.Empty);

        // Distinct
        var result4 = collection1.Distinct();
        foreach(var item in result4) {
            Console.Write(item + " "); // 1 2 3 4 5
        }
        Console.WriteLine(string.Empty);
    }
}

class AnyAllContains : IExample {
    public void Run() {
        var collection = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine(collection.All(x => x > 0)); // true
        Console.WriteLine(collection.All(x => x < 0)); // false
        Console.WriteLine(collection.Any(x => x > 4)); // true
        Console.WriteLine(collection.Contains(5)); // true
        Console.WriteLine(collection.Contains(6)); // false
    }
}

class SkipAndTake : IExample {
    public void Run() {
        var collection = new List<int>() { 1, 2, 3, 4, 5};
        var collection2 = collection.Skip(2);
        foreach(var item in collection2) {
            Console.Write(item + " "); // 3 4 5
        }
        Console.WriteLine(string.Empty);

        var collection3 = collection.Take(2);
        foreach(var item in collection3) {
            Console.Write(item + " "); // 1 2
        }
        Console.WriteLine(string.Empty);
    }
}

class JoinAndGroupJoin : IExample {
    class Person {
        public readonly string Name;
        public readonly int Age;

        public Person(string Name, int Age) {
            this.Name = Name;
            this.Age = Age;
        }

        public override string ToString() {
            return this.Name + ":" + this.Age;
        }
    }

    class Age {
        public readonly int AgeNumber;
        public readonly string AgeLabel;

        public Age(int AgeNumber, string AgeLabel) {
            this.AgeNumber = AgeNumber;
            this.AgeLabel = AgeLabel;
        }
    }

    public void Run() {
        var intList1 = new List<int>() { 1, 2, 3, 4 };
        var intList2 = new List<int>() { 1, 2, 3, 5, 6 };
        var innerJoin = intList1.Join(intList2, int1 => int1, int2 => int2, (int1, int2) => int1);
        foreach(var item in innerJoin) {
            Console.Write(item + " "); // 1, 2, 3
        }
        Console.WriteLine(string.Empty);

        var peopleList = new List<Person>() {
            new Person("John", 25),
            new Person("Ashley", 30),
            new Person("Bob", 30),
            new Person("Sarah", 25),
            new Person("Jim", 25),
            new Person("Vinny", 40)
        };

        var agesList = new List<Age>() {
            new Age(25, "25 year olds"),
            new Age(30, "30 year olds"),
            new Age(40, "40 year olds")
        };

        var groupJoin = agesList.GroupJoin(
            peopleList,
            age => age.AgeNumber,
            person => person.Age,
            (age, personGroup) => new { PersonGroup = personGroup, Number = age.AgeLabel }
        );

        foreach(var item in groupJoin) {
            Console.WriteLine("---" + item.Number + "---");
            foreach(var person in item.PersonGroup) {
                Console.WriteLine(person.Name);
            }
        }
        Console.WriteLine(string.Empty);
        /*
        ---25 year olds---
        John
        Sarah
        Jim
        ---30 year olds---
        Ashley
        Bob
        ---40 year olds---
        Vinny
        */
    }
}

class SequenceEqual : IExample {
    class Person {
        public readonly string Name;
        public readonly int Age;

        public Person(string Name, int Age) {
            this.Name = Name;
            this.Age = Age;
        }

        public override string ToString() {
            return this.Name + ":" + this.Age;
        }
    }

    public void Run() {
        var letters = new List<string>() { "a", "b", "c", "d" };
        var letters2 = new List<string>() { "a", "b", "c", "d" };
        var letters3 = new List<string>() { "a", "b", "c", "d", "e"};

        Console.WriteLine(letters.SequenceEqual(letters2)); // true
        Console.WriteLine(letters.SequenceEqual(letters3)); // false

        // a similar example with reference types rather than value types
        var people = new List<Person>() { new Person("John", 25) };
        var people2 = new List<Person>() { new Person("John", 25) };
        Console.WriteLine(people.SequenceEqual(people2)); // false

        var person = new Person("John", 30);
        var people3 = new List<Person>() { person };
        var people4 = new List<Person>() { person };
        Console.WriteLine(people3.SequenceEqual(people4)); // true    
    }
}

class FirstLastSingleElementAt : IExample {
    public void Run() {
        var letters = new List<string>() { "a", "b", "c", "d" };
        Console.WriteLine(letters.First()); // a
        Console.WriteLine(letters.Last());  // d
        Console.WriteLine(letters.ElementAt(2)); // c
        Console.WriteLine(letters.Single(x => x.Equals("b"))); // 'b', throws error if no match
    }
}

class Concat : IExample {
    public void Run() {
        var letters = new List<string>() { "a", "b", "c" };
        var letters2 = new List<string>() { "d", "e", "f" };
        var letters3 = letters.Concat(letters2);
        foreach(var item in letters3) {
            Console.Write(item + " "); // a b c d e f
        }
        Console.WriteLine(string.Empty);
    }
}

class AggregateAndCount : IExample {
    public void Run() {
        List<int> integers = new List<int>() { 2, 4, 6, 8};
        int total = integers.Aggregate((int1, int2) => int1 + int2);
        Console.WriteLine("Total = " + total); // Total = 20
        Console.WriteLine(integers.Count());   // 4
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample> {
            new BasicQuery(),
            new Cast(),
            new SelectAndSelectMany(),
            new OfType_Where(),
            new OrderBy_ThenBy_Reverse(),
            new GroupBy(),
            new DistinctExceptIntersectUnion(),
            new AnyAllContains(),
            new SkipAndTake(),
            new JoinAndGroupJoin(),
            new SequenceEqual(),
            new FirstLastSingleElementAt(),
            new Concat(),
            new AggregateAndCount()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
