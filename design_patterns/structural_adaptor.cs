// csc structural_adaptor.cs && structural_adaptor && del structural_adaptor.exe
using System;
using System.Collections.Generic;


// we want a common interface
interface IAnimal {
    void Talk();
}


class Man : IAnimal {
    public void Talk() {
        Console.WriteLine("Blah de blah");
    }
}


class Cat {
    public void MakeNoise() {
        Console.WriteLine("Meow de meow");
    }
}


class AdaptedCat : IAnimal {
    Cat cat;

    public AdaptedCat(Cat cat) {
        this.cat = cat;
    }

    public void Talk() {
        this.cat.MakeNoise();
    }
}


class Program {
    public static void Main() {
        List<IAnimal> animals = new List<IAnimal>();
        animals.Add(new Man());
        animals.Add(new AdaptedCat(new Cat()));

        foreach(IAnimal animal in animals) {
            animal.Talk();
        }

        /*
        Blah de blah
        Meow de meow
        */
    }
}