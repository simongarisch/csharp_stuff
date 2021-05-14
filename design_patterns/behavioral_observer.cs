// csc behavioral_observer.cs && behavioral_observer && del behavioral_observer.exe
using System;
using System.Collections.Generic;


interface IObserver {
    void Update(String details);
}


interface ISubject {
    void Register(IObserver observer);
    void Deregister(IObserver observer);
    void Notify();
}


class StockItem : ISubject {
    String name;
    bool inStock;
    HashSet<IObserver> observers = new HashSet<IObserver>();

    public StockItem(String name) {
        this.name = name;
        this.inStock = false;
    }

    public void UpdateAvailabilty(bool inStock) {
        if (inStock) {
            Console.WriteLine(this.name + " is now in stock");
        } else {
            Console.WriteLine(this.name + " is out of stock");
        }
        this.inStock = inStock;
        Notify();
    }

    public void Register(IObserver observer) {
        this.observers.Add(observer);
    }

    public void Deregister(IObserver observer) {
        this.observers.Remove(observer);
    }

    public void Notify() {
        foreach(IObserver observer in observers) {
            observer.Update(this.ToString());
        }
    }

    public override String ToString() {
        if (this.inStock) {
            return this.name + " is now in stock";
        }
        return this.name + " is out of stock";
    }
}


class Customer : IObserver {
    public readonly String name;

    public Customer(String name) {
        this.name = name;
    }

    public void Update(String details) {
        Console.WriteLine(this.name + " receives '" + details + "'");
    }
}


class Program {
    public static void Main() {
        StockItem shirt = new StockItem("Nike Shirt");
        Customer observer1 = new Customer("Bob");
        Customer observer2 = new Customer("Carol");

        shirt.Register(observer1);
        shirt.Register(observer2);

        shirt.UpdateAvailabilty(true);
        /*
        Nike Shirt is now in stock
        Bob receives 'Nike Shirt is now in stock'
        Carol receives 'Nike Shirt is now in stock'
         */

         shirt.UpdateAvailabilty(false);
        /*
        Nike Shirt is out of stock
        Bob receives 'Nike Shirt is out of stock'
        Carol receives 'Nike Shirt is out of stock'
         */
    }
}
