// csc creational_prototype.cs && creational_prototype && del creational_prototype.exe
// https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone?view=net-5.0
using System;
using System.Collections.Generic;


class Dog {
    public String Nickname {get; set;}
    public String Sound {get; set;}

    public Dog(String Nickname, String Sound) {
        this.Nickname = Nickname;
        this.Sound = Sound;
    }

    public Dog ShallowCopy() {
       return (Dog) this.MemberwiseClone();
    }

    public Dog DeepCopy() {
        Dog other = (Dog) this.MemberwiseClone();
        other.Nickname = String.Copy(Nickname);
        other.Sound = String.Copy(Sound);
        return other;
    }

    public override string ToString() {
        return Nickname + " " + Sound;
    }
}


class DogPrototypes {
    Dictionary<string, Dog> Prototypes;

    public DogPrototypes() {
        Prototypes = new Dictionary<string, Dog>();
    }

    public void Register(String Name, Dog Instance) {
        Prototypes.Add(Name, Instance);
    }

    public void Unregister(String Name) {
        Prototypes.Remove(Name);
    }

    public Dog Clone(String Name) {
        if (Prototypes.ContainsKey(Name)) {
            return (Dog)Prototypes[Name].DeepCopy();
        }
        throw new KeyNotFoundException(Name);
    }
}


class Program {
    public static void Main() {
        Dog dog1 = new Dog("Fido", "Woof");
        Console.WriteLine(dog1.ToString()); // Fido Woof

        DogPrototypes prototypes = new DogPrototypes();
        prototypes.Register("Fido", dog1);

        Dog dog2 = prototypes.Clone("Fido");
        Console.WriteLine(dog2.ToString()); // Fido Woof

        dog2.Nickname = "Catdog";
	    dog2.Sound = "Meow";
        Console.WriteLine(dog2.ToString()); // Catdog Meow
    }
}
