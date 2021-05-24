// dotnet add package Microsoft.CodeAnalysis.CSharp.Scripting --version 3.9.0
// https://gsferreira.com/archive/2016/02/the-shining-new-csharp-scripting-api/
// https://github.com/dotnet/roslyn
// https://github.com/dotnet/roslyn/issues/16897
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Scripting;


interface IExample {
    void Run();
}


class BasicExample : IExample {
    public async void Run() {
        var value = await CSharpScript.EvaluateAsync("1 + 2");
        Console.WriteLine(value.GetType().Name + ": " + value); // Int32: 3
    }
}


public class Globals {
    public int NumberOfStudents;
    public int StudentsPerClass;
}


class BasicExample2 : IExample {
    public void Run() {
        var globals = new Globals {
            NumberOfStudents = 80,
            StudentsPerClass = 10
        };

        ScriptState state = null;
        CSharpScript.RunAsync(@"
            bool shouldOpenClass = NumberOfStudents >= StudentsPerClass;
            int numberOfClasses = NumberOfStudents/StudentsPerClass;
        ", globals: globals)
        .ContinueWith(s => state = s.Result).Wait();

        Console.WriteLine(state.GetVariable("shouldOpenClass").Value); // True
        Console.WriteLine(state.GetVariable("numberOfClasses").Value); // 8
    }
}


class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new BasicExample());
        examples.Add(new BasicExample2());

        foreach(IExample example in examples) {
            Console.WriteLine(example.GetType().Name);
            example.Run();
            Console.WriteLine("============");
        }
    }
}
