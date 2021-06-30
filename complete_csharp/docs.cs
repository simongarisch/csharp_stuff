// csc docs.cs && docs && del docs.exe
// XML documentation comments start with ///
// Can generate an XML file at compile time.
using System;

/// <summary>
/// The Example class we use for tutorials.
/// </summary>
/// <remarks>
/// More info about the class goes here.
/// </remarks>
/// <include file="docs.xml" path="docs/members[@name="example"]/Example">
namespace ExampleProject {
    class Example {
        /// <summary>
        /// Adds two integers.
        /// </summary>
        /// <example>
        /// <code>
        /// int c = Example.Add(1, 2);
        /// </code>
        /// </example>
        /// <param name="a">Some comments on a</param>
        /// <param name="b">Some comments on b</param>
        /// <returns>The sum of two integers</returns>
        public static int  Add(int a, int b) {
            return a + b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets the value of Val.</value>
        /// <remarks>
        /// <para>Here is a paragraph.</para>
        /// <para>And here is another.</para>
        /// </remarks>
        public static string Val { get; private set; }

        public void YetAnotherMethod() {
            var x = Example.Add(1, 2);
            var y = Example.Divide(4, 2);
        }

        /// <summary>Divides two integers.</summary>
        /// <param name="a">Some comments on param a.</param>
        /// <param name="b">Some comments on param b.</param>
        /// <returns>The result of dividing two numbers.</returns>
        /// <exception cref="System.DivideByZeroException">Thrown when we attempt to divide by zero</exception>
        public static int Divide(int a, int b) {
            return a / b;
        }

        public static void Main() {
            Console.WriteLine("Hi there");
        }
    }

    /// <summary></summary>
    /// <typeparam name="message">The message to print, can be any type</typeparam>
    /// <returns>
    /// </returns>
    /// Prints a message <typeparamref name="message"/> to the console.
    //public static bool PrintMessage(T message) { return true; }

    /// <summary>
    /// <list type="bullet">
    /// <item>
    /// <term>Add</term>
    /// <description>Addition</description>
    /// </item>
    /// <item>
    /// <term>Subtract</term>
    /// <description>Subtraction</description>
    /// </item>
    /// </list>
    /// </summary>
    public class Math { }
}
