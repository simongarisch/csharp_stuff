// dotnet add package ExcelDna.AddIn --version 1.1.1
// https://excel-dna.net/
// https://github.com/Excel-DNA/ExcelDna/issues/175
// Doesn't look like this supports dotnet core...
using ExcelDna.Integration;


public static class MyFunctions {
    [ExcelFunction(Description = "My first .NET function")]
    public static string SayHello(string name) {
        return "Hello " + name;
    }
}
