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

                Console.WriteLine("Enter first number");
                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.WriteLine("Enter second number");
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.WriteLine("Enter operation to calculate");
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);

                Console.WriteLine("Result = " + result);
            }
            catch (Exception ex)
            {
                //In real world we log the message
                Console.WriteLine("Error : " + ex.Message);
            }
        }

    }
}
