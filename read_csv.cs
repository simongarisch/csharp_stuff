// csc read_csv.cs && read_csv && del read_csv.exe
// https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readlines?view=net-5.0
using System;
using System.Collections.Generic;
using System.IO;   // for File.ReadLines
using System.Linq; // for Example2
using System.Text.RegularExpressions; // for Regex



class Example1 {
    public static void Read(string path) {
        string[] lines = System.IO.File.ReadAllLines(path);
        foreach(string line in lines) {
            string[] items = line.Split(',');
            foreach(string item in items) {
                Console.Write(item + ",");
            }
            Console.WriteLine();
        }
    }
}


class Example2 {
    public static void Read(string path) {
        // for most cases you should avoid splitting based on ',' only because you could have coma in string.
        // https://stackoverflow.com/questions/5116604/read-csv-using-linq
        var csvlines = File.ReadAllLines(path).Skip(1);
        var query = from csvline in csvlines
            let data = csvline.Split(',')
            select new {
                Header1 = data[0],
                Header2 = data[1],
                Header3 = data[2],
            };

        // Console.WriteLine(contents.GetType().Name);
        // Console.WriteLine(contents);
        foreach(var row in query) {
            Console.WriteLine(row);
        }
    }
}


class Example3 {
    public static void Read(string path) {
        List<List<string>> contents = new List<List<string>>();

        var reader = new StreamReader(File.OpenRead(path));
        while (!reader.EndOfStream) {
            var line = reader.ReadLine();
            var row = line.Split(',').ToList();
            contents.Add(row);
        }

        foreach(var row in contents) {
            foreach(var item in row) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}


class Example4 {
    public static void Read(string path) {
        var lines = File.ReadAllLines(path)
            .Skip(1)
            .Where(row => row.Length > 0)
            .Select(row => row.Split(',').ToList())
            .ToList();

        foreach(var row in lines) {
            foreach(var item in row) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program {
    public static void Main() {
        string path = "read_csv.csv";
        Example1.Read(path);
        /*
        header1,header2,header3,
        1,2,3,
        4,5,6,
        */

        Example2.Read(path);
        /*
        { Header1 = 1, Header2 = 2, Header3 = 3 }
        { Header1 = 4, Header2 = 5, Header3 = 6 }
        */

        Example3.Read(path);
        /*
        header1 header2 header3 
        1 2 3
        4 5 6
        */
        
        Example4.Read(path);
        /*
        1 2 3
        4 5 6
         */
    }
}
