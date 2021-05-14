// csc behavioral_strategy.cs && behavioral_strategy && del behavioral_strategy.exe
using System;


interface IReadingStrategy {
    void Read();
}


class ReadAloud : IReadingStrategy {
    public void Read() {
        Console.WriteLine("Blah blah blah");
    }
}


class SpeedRead : IReadingStrategy {
    public void Read() {
        Console.WriteLine("Faster than a speeding bullet");
    }
}


class SkimRead : IReadingStrategy {
    public void Read() {
        Console.WriteLine("Faster... speeding ...");
    }
}


class Kindle : IReadingStrategy {
    IReadingStrategy readingStrategy;

    public Kindle(IReadingStrategy readingStrategy) {
        this.readingStrategy = readingStrategy;
    }

    public void Read() {
        this.readingStrategy.Read();
    }
}


class Program {
    public static void Main() {
        Kindle kindle;

        kindle = new Kindle(new ReadAloud());
        kindle.Read(); // Blah blah blah

        kindle = new Kindle(new SpeedRead());
        kindle.Read(); // Faster than a speeding bullet

        kindle = new Kindle(new SkimRead());
        kindle.Read(); // Faster... speeding ...
    }
}
