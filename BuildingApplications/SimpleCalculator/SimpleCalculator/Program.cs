using System;


namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputConverter inputConverter = new InputConverter();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                Console.Write("Please enter a number (x): ");
                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

                Console.Write("Please enter a number (y): ");
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

                Console.Write("Please enter an operation (+ - * /): ");
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                Console.WriteLine($"The result is {result}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // in the real world we'll want to log this message
                Console.WriteLine(ex.Message);
            }
        }
    }
}
