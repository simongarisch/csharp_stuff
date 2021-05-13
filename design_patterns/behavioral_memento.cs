// csc behavioral_memento.cs && behavioral_memento && del behavioral_memento.exe
using System;


class CheckPointMemento {
    public int CheckPointLevel {get; set;}
    public int CheckPointScore {get; set;}

    public CheckPointMemento(int level, int score) {
        this.CheckPointLevel = level;
        this.CheckPointScore = score;
    }
}


class CheckPointCaretaker {
    public CheckPointMemento CheckPoint {get; set;}

    public CheckPointCaretaker(CheckPointMemento CheckPoint) {
        this.CheckPoint = CheckPoint;
    }
}


class PlayerStatistics {
    public int level {get; set;}
    public int score {get; set;}

    public PlayerStatistics(int level, int score) {
        this.level = level;
        this.score = score;
    }

    public CheckPointMemento CreateCheckPoint() {
        return new CheckPointMemento(this.level, this.score);
    }

    public void RestoreCheckPoint(CheckPointMemento checkPointMemento) {
        this.level = checkPointMemento.CheckPointLevel;
        this.score = checkPointMemento.CheckPointScore;
    }

    public void PrintStatistics() {
        Console.WriteLine("Level is: " + this.level);
        Console.WriteLine("Score is: " + this.score);
        Console.WriteLine("-----------------------");
    }
}


class Program {
    public static void Main() {
        PlayerStatistics stats = new PlayerStatistics(1, 100);
        stats.PrintStatistics();

        CheckPointCaretaker caretaker = new CheckPointCaretaker(stats.CreateCheckPoint());
        stats.level = 2;
        stats.score = 200;
        stats.PrintStatistics();

        stats.RestoreCheckPoint(caretaker.CheckPoint);
        stats.PrintStatistics();

        /*
        Level is: 1
        Score is: 100
        -----------------------
        Level is: 2
        Score is: 200
        -----------------------
        Level is: 1
        Score is: 100
        -----------------------
         */
    }
}
