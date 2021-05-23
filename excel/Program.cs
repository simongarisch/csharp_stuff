// dotnet add package ClosedXML
using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;


interface IExample {
    void Run();
}


class BasicExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook();
        var ws = wbook.Worksheets.Add("Sheet1");
        ws.Cell("A1").Value = "Hello, World!";
        ws.Cell("A2").FormulaA1 = "=MID(A1,7,5)";
        ws.Cell("A3").FormulaA1 = "SUM(B1:B7)";
        wbook.SaveAs(this.GetType().Name + ".xlsx");
    }
}


class CellExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook();
        var ws = wbook.AddWorksheet("Sheet1");

        ws.FirstCell().Value = 150;
        ws.Cell(3, 2).Value = "Hello there!";
        ws.Cell("A6").SetValue("falcon").SetActive();
        ws.Column(2).AdjustToContents();
        wbook.SaveAs(this.GetType().Name + ".xlsx");
    }
}


class ReadExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook("BasicExample.xlsx");
        var ws1 = wbook.Worksheet(1);
        var data = ws1.Cell("A1").GetValue<string>();
        Console.WriteLine(data); // Hello, World!
    }
}


class StylingExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook();
        var ws = wbook.Worksheets.Add("Sheet1");

        var c1 = ws.Column("A");
        c1.Width = 25;

        var c2 = ws.Column("B");
        c2.Width = 15;

        ws.Cell("A3").Value = "an old falcon";
        ws.Cell("B2").Value = "150";
        ws.Cell("B5").Value = "Sunny day";

        ws.Cell("A3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        ws.Cell("A3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Cell("A3").Style.Font.Italic = true;

        ws.Cell("B2").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        ws.Cell("B5").Style.Font.FontColor = XLColor.Red;

        wbook.SaveAs(this.GetType().Name + ".xlsx");
    }
}


class RangesExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook();
        var ws = wbook.Worksheets.Add("Sheet1");

        ws.Range("D2:E2").Style.Fill.BackgroundColor = XLColor.Gray;
        ws.Ranges("C5, F5:G8").Style.Fill.BackgroundColor = XLColor.Gray;

        var rand = new Random();
        var range = ws.Range("C10:E15");
        foreach (var cell in range.Cells()) {
            cell.Value = rand.Next();
        }

        ws.Column("C").AdjustToContents();
        ws.Column("D").AdjustToContents();
        ws.Column("E").AdjustToContents();

        wbook.SaveAs(this.GetType().Name + ".xlsx");
    }
}


class MergingCellsExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook();
        var ws = wbook.Worksheets.Add("Sheet1");

        ws.Cell("A1").Value = "Sunny day";
        ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        ws.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

        ws.Range("A1:B2").Merge();
        wbook.SaveAs(this.GetType().Name + ".xlsx");
    }
}


class SortingExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook();
        var ws = wbook.Worksheets.Add("Sheet1");

        var rand = new Random();
        var range = ws.Range("A1:A15");
        foreach (var cell in range.Cells()) {
            cell.Value = rand.Next(1, 100);
        }

        ws.Sort("A");
        wbook.SaveAs(this.GetType().Name + ".xlsx");
    }
}


class CellsUsedExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook();
        var ws = wbook.Worksheets.Add("Sheet1");

        ws.Cell("A1").Value = "sky";
        ws.Cell("A2").Value = "cloud";
        ws.Cell("A3").Value = "book";
        ws.Cell("A4").Value = "cup";
        ws.Cell("A5").Value = "snake";
        ws.Cell("A6").Value = "falcon";
        ws.Cell("B1").Value = "in";
        ws.Cell("B2").Value = "tool";
        ws.Cell("B3").Value = "war";
        ws.Cell("B4").Value = "snow";
        ws.Cell("B5").Value = "tree";
        ws.Cell("B6").Value = "ten";

        var n = ws.Range("A1:C10").CellsUsed().Count();
        Console.WriteLine($"There are {n} words in the range");
        Console.WriteLine("The following words have three latin letters:");
        var words = ws.Range("A1:C10")
            .CellsUsed()
            .Select(c => c.Value.ToString())
            .Where(c => c?.Length == 3)
            .ToList();

        words.ForEach(Console.WriteLine);

        wbook.SaveAs(this.GetType().Name + ".xlsx");
    }
}


class ExpressionEvaluationExample : IExample {
    public void Run() {
        using var wbook = new XLWorkbook("SortingExample.xlsx");

        var ws = wbook.Worksheet(1); 

        var sum = ws.Evaluate("SUM(A1:A3)");
        var max = ws.Evaluate("MAX(A1:A3)");

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The maximum valus is: {max}");
    }
}



class Program {
    static void Main(string[] args) {
        List<IExample> examples = new List<IExample>();
        examples.Add(new BasicExample());
        examples.Add(new CellExample());
        examples.Add(new ReadExample());
        examples.Add(new StylingExample());
        examples.Add(new RangesExample());
        examples.Add(new MergingCellsExample());
        examples.Add(new SortingExample());
        examples.Add(new CellsUsedExample());

        foreach(IExample example in examples) {
            Console.WriteLine($"Running {example.GetType().Name} example...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
