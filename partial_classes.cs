// csc partial_classes.cs && partial_classes && del partial_classes.exe
// In C#, you can split the implementation of a class, a struct, a method,
// or an interface in multiple .cs files using the partial keyword.
using System;


public partial class Employee {
    public int EmpId { get; set; }
    public string Name { get; set; }
}


public partial class Employee {
    public Employee(int id, string name) {
        this.EmpId = id;
        this.Name = name;
    }

    public void DisplayEmpInfo() {
        Console.WriteLine(this.EmpId + " " + this.Name);
    }
}


class Program {
    public static void Main() {
        Employee employee = new Employee(1, "Simon");
        employee.DisplayEmpInfo(); // 1 Simon
    }
}
