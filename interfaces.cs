// csc interfaces.cs && interfaces && del interfaces.exe
using System;
using System.Collections.Generic;


interface IAnimal {
    void MakeSound();
}


class Pig : IAnimal {
    public void MakeSound() {
        Console.WriteLine("Ree ree");
    }
}


class Dog : IAnimal {
    public void MakeSound() {
        Console.WriteLine("Woof");
    }
}


class Cat : IAnimal {
    public void MakeSound() {
        Console.WriteLine("Meow");
    }
}


class Program {
    public static void Main() {
        List<IAnimal> animals = new List<IAnimal>();
        animals.Add(new Pig());
        animals.Add(new Dog());
        animals.Add(new Cat());

        foreach(IAnimal animal in animals) {
            animal.MakeSound();
        }

        // Ree ree
        // Woof
        // Meow
    }
}
