// dotnet add package DynamicLua --version 1.1.2
// dotnet add package NLua --version 1.5.9
// https://stackoverflow.com/questions/22267758/how-to-embed-lua-or-some-other-scripting-language-in-a-c-sharp-5-0-application
// Note that the DynamicLua project is old... perhaps best to go with C# stripting or NLUA
// Using NLUA in the examples below
// https://github.com/NLua/NLua
// https://www.cs-script.net/
using System;
using NLua;


class MyClass
{
    public int x { get; set; }
    public int y { get; set; }

    public MyClass(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}


class Program
{
    public static void Main()
    {
        Lua state = new Lua();

        // basic operations
        state.DoString("y = 10 + 5");
        double y = (double)state["y"]; // Retrieve the value of y
        Console.WriteLine(y); // 15

        // calling lua functions
        state.DoString(@"
        function ScriptFunc (val1, val2)
            if val1 > val2 then
                return val1 + 1
            else
                return val2 - 1
            end
        end
        ");

        var scriptFunc = state["ScriptFunc"] as LuaFunction;
        // Console.WriteLine(scriptFunc.GetType().Name); // LuaFunction
        var res = (System.Int64)scriptFunc.Call(3, 5)[0];
        Console.WriteLine(res); // 4

        // passing .NET objects to the state
        var mc = new MyClass(1, 2);
        state["mc"] = mc;
        state.DoString("mc.x = 7; mc.y = 10;");

        var mc2 = (MyClass)state["mc"];
        Console.WriteLine(mc2.x); // 7
        Console.WriteLine(mc2.y); // 10
    }
}
