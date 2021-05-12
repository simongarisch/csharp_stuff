// csc creational_abstractfactory.cs && creational_abstractfactory && del creational_abstractfactory.exe
using System;
using System.Collections.Generic;

class Vehicle {
    String make {get; set;}
    String model {get; set;}
    List<string> parts;

    public Vehicle(String make, String model) {
        this.make = make;
        this.model = model;
        parts = new List<string>();
    }

    public void AddPart(String part) {
        parts.Add(part);
    }

    public void ShowParts() {
        foreach(String part in parts) {
            Console.WriteLine(part);
        }
    }

    public override string ToString() {
        return make + " " + model;
    }
}


interface IFactory {
    String Build (String make, String model);
}


class VehicleChassisFactory : IFactory {
    public String Build(String make, String model) {
        return "Chassis for a " + make + " " + model;
    }
}

class VehicleEngineFactory : IFactory {
    public String Build(String make, String model) {
        return "Engine for a " + make + " " + model;
    }
}

class VehicleBodyFactory : IFactory {
    public String Build(String make, String model) {
        return "Body for a " + make + " " + model;
    }
}

class VehicleFactory {
    Vehicle vehicle;
    static List<IFactory> subFactories = new List<IFactory>() {
        new VehicleChassisFactory(),
        new VehicleEngineFactory(),
        new VehicleBodyFactory(),
    };

    public Vehicle Build(String make, String model) {
        vehicle = new Vehicle(make, model);
        foreach(IFactory subFactory in subFactories) {
            vehicle.AddPart(subFactory.Build(make, model));
        }
        return vehicle;
    }
}


class Program {
    public static void Main() {
        VehicleFactory factory = new VehicleFactory();
        Vehicle vehicle = factory.Build("Ford", "Mustang");
        Console.WriteLine(vehicle.ToString()); // Ford Mustang

        vehicle.ShowParts();
        /*
        Chassis for a Ford Mustang
        Engine for a Ford Mustang
        Body for a Ford Mustang
         */
    }
}
