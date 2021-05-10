// csc inheritance.cs && inheritance && del inheritance.exe
using System;

class Vehicle  // base class (parent) 
{
  public string brand = "Ford";  // Vehicle field
  public void honk()             // Vehicle method 
  {                    
    Console.WriteLine("Tuut, tuut!");
  }
}

class Car : Vehicle  // derived class (child)
{
  public string modelName = "Mustang";  // Car field
}

class Program
{
  static void Main(string[] args)
  {
    Car myCar = new Car();
    myCar.honk(); // Tuut, tuut!
    Console.WriteLine(myCar.brand + " " + myCar.modelName); // Ford Mustang
  }
}
