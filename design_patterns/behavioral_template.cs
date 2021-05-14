// csc behavioral_template.cs && behavioral_template && del behavioral_template.exe
// https://www.c-sharpcorner.com/UploadFile/b1df45/template-design-pattern-in-C-Sharp/
using System;


abstract class HiringProcess {
    public void HireFreshers() {
        FirstRoundTest();
        GroupDiscussion();
        TechnicalInterview();
        HRInterview();
    }

    public abstract void FirstRoundTest();

    public abstract void TechnicalInterview();

    private void GroupDiscussion() {
        Console.WriteLine("Conduct group discussion.");
    }

    private void HRInterview() {
        Console.WriteLine("Conduct HR Interview.");
    }
}


class CSEDepartment : HiringProcess {
    public override void FirstRoundTest() {
        Console.WriteLine("Conduct CSE department tests.");
    }

    public override void TechnicalInterview() {
        Console.WriteLine("Conduct CSE department technical interviews.");
    }
}


class ElectronicDepartment : HiringProcess {
    public override void FirstRoundTest() {
        Console.WriteLine("Conduct Electronic department tests.");
    }

    public override void TechnicalInterview() {
        Console.WriteLine("Conduct Electronic department technical interviews.");
    }
}


class Program {
    public static void Main() {
        HiringProcess hiringProcess = new CSEDepartment();
        Console.WriteLine("Hiring CSE students");
        hiringProcess.HireFreshers();
        Console.WriteLine();

        hiringProcess = new ElectronicDepartment();
        Console.WriteLine("Hiring Engineering students");
        hiringProcess.HireFreshers();

        /*
        Hiring CSE students
        Conduct CSE department tests.
        Conduct group discussion.    
        Conduct CSE department technical interviews.
        Conduct HR Interview.

        Hiring Engineering students
        Conduct Electronic department tests.
        Conduct group discussion.
        Conduct Electronic department technical interviews.
        Conduct HR Interview.
         */
    }
}
