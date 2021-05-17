// csc structural_flyweight.cs && structural_flyweight && del structural_flyweight.exe
using System;
using System.Collections.Generic;


enum PresidentType {
    Bush,
    Clinton,
    Trump
}


class RandomPresidentType {
    static Random rnd = new Random();

    public static PresidentType Get() {
        int max = Enum.GetValues(typeof(PresidentType)).Length;
        PresidentType value = (PresidentType)rnd.Next(0, max);
        return value;
    }
}


interface IPresident {
    void GoOffCuff();
}


class PresidentBush : IPresident {
    public void GoOffCuff() {
        Console.WriteLine("To the C students... I say, you too can be President of the United States.");
    }
}


class PresidentClinton : IPresident {
    public void GoOffCuff() {
        Console.WriteLine("I did not have sexual relations with that woman.");
    }
}


class PresidentTrump : IPresident {
    public void GoOffCuff() {
        Console.WriteLine("Grab em by the pu**y.");
    }
}


class PresidentFactory {
    Dictionary<PresidentType, IPresident> flyweights = new Dictionary<PresidentType, IPresident>();
    private int countCreateCalled = 0;

    public IPresident Get(PresidentType presidentType) {
        if (flyweights.ContainsKey(presidentType)) {
            return flyweights[presidentType];
        }

        // we'll have to create the president if it doesn't already
        // exist in our flyweigths dictionary.
        IPresident president = CreateNewPresident(presidentType);
        flyweights[presidentType]= president;
        return president;
    }

    private IPresident CreateNewPresident(PresidentType presidentType) {
        this.countCreateCalled++;
        IPresident president;

        switch (presidentType) {
            case PresidentType.Bush:
                president = new PresidentBush();
                break;
            case PresidentType.Clinton:
                president = new PresidentClinton();
                break;
            case PresidentType.Trump:
                president = new PresidentTrump();
                break;
            default:
                throw new NotImplementedException();
        }

        return president;
    }

    public int GetCountCreateCalled() {
        return this.countCreateCalled;
    }
}


class Program {
    public static void Main() {
        PresidentFactory presidentFactory = new PresidentFactory(); 

        for (int i=0; i<10; i++) {
            var presidentType = RandomPresidentType.Get();
            var president = presidentFactory.Get(presidentType);
            president.GoOffCuff();
        }

        int newPresidentCalls = presidentFactory.GetCountCreateCalled();
        Console.WriteLine("New presidents were instantiated " + newPresidentCalls + " times.");

        /*
        To the C students... I say, you too can be President of the United States.
        I did not have sexual relations with that woman.
        To the C students... I say, you too can be President of the United States.
        I did not have sexual relations with that woman.
        Grab em by the pu**y.
        To the C students... I say, you too can be President of the United States.
        I did not have sexual relations with that woman.
        Grab em by the pu**y.
        Grab em by the pu**y.
        To the C students... I say, you too can be President of the United States.
        New presidents were instantiated 3 times.
         */
    }
}