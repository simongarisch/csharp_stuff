// csc exception_handling.cs && exception_handling && del exception_handling.exe
// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling
// https://stackify.com/csharp-exception-handling-best-practices/
// https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions
using System;


class Program {
    public static int GetInt(int[] array, int index) {
        try {
            return array[index];
        } catch (IndexOutOfRangeException e) {
            throw new ArgumentOutOfRangeException("Parameter index cannot be outside array bounds", e);
        }
    }

    public static void Main() {
        int[] array = new int[] {1, 2, 3, 4, 5};
        int[] indices = new int[] {-1, 0, 1, 2, 3, 4, 5};
        foreach(int index in indices) {
            int value = 0;
            bool success = true;
            try {
                value = Program.GetInt(array, index);
            } catch (Exception e) {
                success = false;
                Console.WriteLine("Failed to fetch index " + index);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();
            } finally {
                if (success) {
                    Console.WriteLine(index + ": " + value);
                }
            }
        }
    }
}