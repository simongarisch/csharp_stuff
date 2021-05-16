// csc structural_decorator.cs && structural_decorator && del structural_decorator.exe
using System;


interface ICalculation {
    int Calc(int input);
}


class Doubler : ICalculation {
    public int Calc(int input) {
        return input * 2;
    }
}


class LogDoubler : ICalculation {
    Doubler doubler;

    public LogDoubler(Doubler doubler) {
        this.doubler = doubler;
    }

    public int Calc(int input) {
        Console.WriteLine("Starting the executioin with integer " + input);
        int result = doubler.Calc(input);
        Console.WriteLine("Execution has completed with the result " + result);
        return result;
    }
}


class Program {
    public static void Main() {
        var logDoubler = new LogDoubler(new Doubler());
        logDoubler.Calc(2);
        /*
        Starting the executioin with integer 2
        Execution has completed with the result 4
         */
    }
}
