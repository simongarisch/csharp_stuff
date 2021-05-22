// csc using.cs && using && del using.exe
// dotnet tool install -g dotnet-script
// dotnet script using.cs
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


interface IExample {
    void Run();
}


class OldSyntax : IExample {
    public void Run() {
        #nullable enable
        string path = "using.txt";
        FileStream? fs = null;
        StreamReader? sr = null;

        try {
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, Encoding.UTF8);
        } finally {
            fs?.Close();
            sr?.Close();
        }
        #nullable disable
    }
}


class NewSyntax : IExample {
    public void Run() {
        string path = "using.txt";
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        using var sr = new StreamReader(fs, Encoding.UTF8);
        
        string content = sr.ReadToEnd();
        Console.WriteLine(content);
        /*
        this is a file
        with some lines
        that we are using as a test
        */
    }
}


class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new OldSyntax());
        examples.Add(new NewSyntax());

        foreach(IExample example in examples) {
            example.Run();
        }
    }
}

// Program.Main();
