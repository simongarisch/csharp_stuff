// csc creational_factory.cs && creational_factory && del creational_factory.exe
using System;

enum PersonType {
  Rural,
  City
}

interface IPerson {
    String GetName();
}


class RuralPerson : IPerson {
    public string GetName() {
        return "Cletus";
    }
}


class CityPerson : IPerson {
    public string GetName() {
        return "Dan the man";
    }
}


class PersonFactory {
    public IPerson Create(PersonType type) {
        switch(type) {
            case PersonType.Rural: return new RuralPerson();
            case PersonType.City: return new CityPerson();
            default: throw new ArgumentException("Invalid type", "type");
        }
    }
}


class Program {
    public static void Main() {
        PersonFactory factory = new PersonFactory();
        IPerson person1 = factory.Create(PersonType.Rural);
        IPerson person2 = factory.Create(PersonType.City);

        Console.WriteLine(person1.GetName()); // Cletus
        Console.WriteLine(person2.GetName()); // Dan the man
    }
}
