// csc yield.cs && yield && del yield.exe

/* 
The yield keyword signals to the compiler that the method in which
it appears is an iterator block. The compiler generates a class to
implement the behavior that is expressed in the iterator block.
In the iterator block, the yield keyword is used together with the
return keyword to provide a value to the enumerator object. This is
the value that is returned, for example, in each loop of a foreach
statement. The yield keyword is also used with break to signal the
end of iteration.
*/
using System;
using System.Collections.Generic;


class Program {
    public static void Main() {
        foreach(var item in func(2,10)) {
            Console.Write(item + ",");
        }
        Console.WriteLine();
        // 2,4,6,8,10,12,14,16,18,20,
    }

    public static IEnumerable<int> func(int start, int number) {
        for (int i=0; i<number; i++) {
            yield return start + 2 * i;
        }
    }
}