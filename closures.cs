// csc closures.cs && closures && del closures.exe
using System;


class Examples {
    public Func<int, int> scale = x => 2 * x;

    static int factor = 3;
    public Func<int, int> scaleF = (k) => factor * k;
}


namespace MyNamespace {
    class Multipliers {
        private static int x = 2;
        private static int y = 3;

        public static int GetX() {
            return x;
        }

        public static int GetY() {
            return y;
        }
    }


    class Scalers {
        public static Func<int, int> scaleX = (k) => Multipliers.GetX() * k;
        public static Func<int, int> scaleY = (k) => Multipliers.GetY() * k;
    }
}

class Program {
    public static void Main() {
        var examples = new Examples();
        Console.WriteLine(examples.scale(2));  // 4
        Console.WriteLine(examples.scaleF(2)); // 6

        Console.WriteLine(MyNamespace.Scalers.scaleX(2));  // 4
        Console.WriteLine(MyNamespace.Scalers.scaleY(2));  // 6
    }
}
