// csc generics.cs && generics && del generics.exe
using System;


public class UnicornList<T> {
    public void Add(T input) { }
}

class TestGenericList {
    private class ExampleClass { }

    public static void Main() {
        // Declare a list of type int.
        UnicornList<int> list1 = new UnicornList<int>();
        list1.Add(1);

        // Declare a list of type string.
        UnicornList<string> list2 = new UnicornList<string>();
        list2.Add("");

        // Declare a list of type ExampleClass.
        UnicornList<ExampleClass> list3 = new UnicornList<ExampleClass>();
        list3.Add(new ExampleClass());
    }
}
