// csc enumerable.cs && enumerable && del enumerable.exe
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-5.0
// https://stackoverflow.com/questions/558304/can-anyone-explain-ienumerable-and-ienumerator-to-me

/*
Any type supporting a method named GetEnumerator()
can be evaluated by the foreach construct.
*/
using System;
using System.Collections;


class Car {
    public readonly string name;
    public readonly int speed;

    public Car(string name, int speed) {
        this.name = name;
        this.speed = speed;
    }
}


class Garage {
    private Car[] carArray = new Car[4];

    public Garage() {
        carArray[0] = new Car("Rusty", 30);
        carArray[1] = new Car("Clunker", 55);
        carArray[2] = new Car("Zippy", 30);
        carArray[3] = new Car("Fred", 30);
    }

    public IEnumerator GetEnumerator() {
        return carArray.GetEnumerator();
    }
}

class Program {
    public static void Main() {
        Garage garage = new Garage();
        foreach(Car car in garage) {
            Console.WriteLine("{0} is going {1} MPH", car.name, car.speed);
        }

        /*
        Rusty is going 30 MPH
        Clunker is going 55 MPH
        Zippy is going 30 MPH
        Fred is going 30 MPH
        */
    }
}
