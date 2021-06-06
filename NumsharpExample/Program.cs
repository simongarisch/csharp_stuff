// dotnet add package NumSharp --version 0.30.0
// https://github.com/SciSharp/NumSharp
using System;
using NumSharp;

namespace NumsharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var nd = np.zeros((2, 3));
            Console.WriteLine(nd.ToString());
            /*
            [[0, 0, 0], 
            [0, 0, 0]]
            */

            // create a tensor
            nd = np.arange(6);
            nd = nd.reshape(2, 3);
            foreach(var val in nd) {
                Console.Write(val.ToString() + " ");
            }
            Console.WriteLine();
            // 0 1 2 3 4 5
        }
    }
}
