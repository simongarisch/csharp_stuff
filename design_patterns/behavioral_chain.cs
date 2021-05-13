// csc behavioral_chain.cs && behavioral_chain && del behavioral_chain.exe
using System;


interface ICleaner {
    void Clean();
    ICleaner SetNext(ICleaner cleaner);
    ICleaner GetNext();
}


abstract class Cleaner : ICleaner {
    ICleaner next;

    public abstract void Clean();

    public void CallNext() {
        if (next != null) {
            next.Clean();
        }
    }

    public ICleaner SetNext(ICleaner cleaner) {
        next = cleaner;
        return cleaner;
    }

    public ICleaner GetNext() {
        return next;
    }
}



class Washer : Cleaner {
    public override void Clean() {
        Console.WriteLine("washing...");
        CallNext();
    }
}

class Polisher : Cleaner {
    public override void Clean() {
        Console.WriteLine("polishing...");
        CallNext();
    }
}

class Buffer : Cleaner {
    public override void Clean() {
        Console.WriteLine("buffing...");
        CallNext();
    }
}


class Program {
    public static void Main() {
        ICleaner washer = new Washer();
        ICleaner polisher = new Polisher();
        ICleaner buffer = new Buffer();

        washer.SetNext(polisher).SetNext(buffer);
        washer.Clean();
        /*
        washing...
        polishing...
        buffing...
         */
    }
}
