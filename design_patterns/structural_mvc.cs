// csc structural_mvc.cs && structural_mvc && del structural_mvc.exe
// https://www.geeksforgeeks.org/mvc-design-pattern/

/*
The Separation of Concerns (SoC) is a design principle for separating a computer program into distinct sections.
With the Model View Controller (MVC) pattern we separate the out the data model, our visual representation or view,
and the controller that decides what model data to show on the view.
*/

using System;


class Student {
    private String rollNo;
    private String name;

    public void setRollNo(String rollNo) {
        this.rollNo = rollNo;
    }

    public String getRollNo() {
        return this.rollNo;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }
}


class StudentView {
    public void printStudentDetails(String name, String rollNo) {
        Console.WriteLine("Student: ");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Roll No: " + rollNo);
    }
}


class StudentController {
    private Student model;
    private StudentView view;
  
    public StudentController(Student model, StudentView view) {
        this.model = model;
        this.view = view;
    }
  
    public void setStudentName(String name) {
        model.setName(name); 
    }
  
    public String getStudentName() {
        return model.getName();        
    }
  
    public void setStudentRollNo(String rollNo) {
        model.setRollNo(rollNo);
    }
  
    public String getStudentRollNo() {
        return model.getRollNo();    
    }
  
    public void updateView() {                
        view.printStudentDetails(model.getName(), model.getRollNo());
    }
}


class Program {
    public static void Main() {
        Student model = retrieveStudentFromDatabase();
        StudentView view = new StudentView();
        StudentController controller = new StudentController(model, view);
        
        controller.updateView();
        controller.setStudentName("Bobby Brozman");
        controller.updateView();

        /*
        Student: 
        Name: Bob Brozman
        Roll No: 15UCS157
        Student:
        Name: Bobby Brozman
        Roll No: 15UCS157
         */
    }

    private static Student retrieveStudentFromDatabase() {
        Student student = new Student();
        student.setName("Bob Brozman");
        student.setRollNo("15UCS157");
        return student;
    }
}
