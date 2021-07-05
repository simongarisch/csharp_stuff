// csc reflection.cs && reflection && del reflection.exe
using System;
using System.Reflection;
using System.Collections.Generic;

interface IExample {
    void Run();
}

class BasicReflection : IExample {
    public void Run() {
        Type t = typeof(int);
        MemberInfo[] typeMembers = t.GetMembers();
        foreach(MemberInfo memberInfo in typeMembers) {
            Console.WriteLine("Member = " + memberInfo);
        }

        Console.WriteLine("-----");
        FieldInfo[] typeFields = t.GetFields();
        foreach(FieldInfo fieldInfo in typeFields) {
            Console.WriteLine("Field = " + fieldInfo);
        }

        Console.WriteLine("-----");
        MethodInfo[] typeMethods = t.GetMethods();
        foreach(MethodInfo methodInfo in typeMethods) {
            Console.WriteLine("Method = " + methodInfo);
        }
    }
}

class ReflectionWithGenericTypes : IExample {
    public void Run() {
        Console.WriteLine("Is string a generic type: " + typeof(string).IsGenericType); // false
        Console.WriteLine("Is List a generic type: " + typeof(List<>).IsGenericType);   // true

        Type t = typeof(Dictionary<,>);
        if (t.IsGenericType) {
            Type[] typeParameters = t.GetGenericArguments();
            Console.WriteLine("Number of type parameters = {0}", typeParameters.Length);
            foreach(Type tParam in typeParameters) {
                if (tParam.IsGenericParameter) {
                    Console.WriteLine("Generic Type = {0}", tParam);
                } else {
                    Console.WriteLine("Type = {0}", tParam);
                }
            }
        }
        /*
        Number of type parameters = 2
        Generic Type = TKey
        Generic Type = TValue
        */
    }
}

class Program {
    public static void Main() {
        var examples = new List<IExample>() {
            new BasicReflection(),
            new ReflectionWithGenericTypes()
        };

        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine();
        }
    }
}