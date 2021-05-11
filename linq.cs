// csc linq.cs && linq && del linq.exe
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


interface IExample {
    void Run();
}


class BasicExample : IExample {
    public void Run() {
        string[] names = {"Bill", "Steve", "James", "Mohan"};

        var linqQuery = from name in names
            where name.Contains("a")
            select name;
        
        foreach(string name in linqQuery) {
            Console.WriteLine(name);
        }
    }
}


class Student {
    public int StudentID { get; set; }
    public String StudentName { get; set; }
    public int Age { get; set; }

    public override string ToString() {
        String id = StudentID.ToString();
        String age = Age.ToString();
        return "Student{" + id + ", " + StudentName + ", " + age + "}";
    }
}


class StudentExample : IExample {
    public void Run() {
        Student[] studentArray = { 
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve", Age = 21 },
            new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 },
            new Student() { StudentID = 6, StudentName = "Chris", Age = 17 },
            new Student() { StudentID = 7, StudentName = "Rob", Age = 19 },
        };

        Student[] teenagerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();
        List<Student> olderStudents = studentArray.Where(s => s.Age >= 30).ToList();
        Student bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();
        Student anne = studentArray.Where(s => s.StudentName == "Anne").FirstOrDefault();
        Student student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();

        foreach(Student student in teenagerStudents) {
            Console.WriteLine(student.ToString());
        }
        // Student{1, John, 18}
        // Student{6, Chris, 17}
        // Student{7, Rob, 19}

        Console.WriteLine(bill.ToString());  // Student{3, Bill, 25}

        bool anneExists = (anne != null);
        Console.WriteLine(anneExists.ToString()); // False
    }
}


class OfTypeExample : IExample {
    public void Run() {
        IList mixedList = new ArrayList();
        mixedList.Add(0);
        mixedList.Add("One");
        mixedList.Add("Two");
        mixedList.Add(3);
        mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill", Age = 21 });

        var stringResult = from s in mixedList.OfType<string>() select s;
        var intResult = from s in mixedList.OfType<int>() select s;
        var studentResult = from s in mixedList.OfType<Student>() select s;

        foreach(String s in stringResult) {
            Console.WriteLine(s);
        }
        // One
        // Two

        foreach(int i in intResult) {
            Console.WriteLine(i);
        }
        // 0
        // 3

        foreach(Student s in studentResult) {
            Console.WriteLine(s);
        }
        // Student{1, Bill, 21}
    }
}


class OrderingExample : IExample {
    public void Run() {
        List<Student> studentList = new List<Student>() { 
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 },
            new Student() { StudentID = 6, StudentName = "Ram" , Age = 18 },
        };

        List<Student> thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age).ToList();
        List<Student> thenByDescResult = studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age).ToList();
        foreach(Student student in thenByDescResult) {
            Console.WriteLine(student.ToString());
        }
        /*
            Student{3, Bill, 25}
            Student{1, John, 18}
            Student{4, Ram, 20}
            Student{6, Ram, 18}
            Student{5, Ron, 19}
            Student{2, Steve, 15}
         */
    }
}


class GroupByExample : IExample {
    public void Run() {
        IList<Student> studentList = new List<Student>() { 
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
            new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }, 
        };

        var groupedResult = studentList.GroupBy(s => s.Age);
        foreach (var ageGroup in groupedResult) {
            Console.WriteLine("--- Age Group: {0} ---", ageGroup.Key);      
            foreach(Student s in ageGroup) {
                Console.WriteLine("Student Name: {0}", s.StudentName);
            }
            Console.WriteLine();
        }
        /*
            --- Age Group: 18 ---
            Student Name: John
            Student Name: Bill

            --- Age Group: 21 ---
            Student Name: Steve
            Student Name: Abram

            --- Age Group: 20 ---
            Student Name: Ram
        */
    }
}


class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new BasicExample());
        examples.Add(new StudentExample());
        examples.Add(new OfTypeExample());
        examples.Add(new OrderingExample());
        examples.Add(new GroupByExample());

        foreach(IExample example in examples) {
            String className = example.GetType().FullName.ToString();
            Console.WriteLine("--- " + className + " ---");
            example.Run();
            Console.WriteLine("-----");
        }
    }
}
