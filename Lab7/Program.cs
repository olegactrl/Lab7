using System;

namespace Lab7
{
    internal class Program
    {
        public static void Main()
        {
            Calculator<double> doubleCalculator = new Calculator<double>(
            (a, b) => a + b,
            (a, b) => a - b,
            (a, b) => a * b,
            (a, b) => a / b
        );
            Console.WriteLine(doubleCalculator.Addition(5.8, 6.3));
            Console.WriteLine(doubleCalculator.Subtraction(5.8, 6.3));
            Console.WriteLine(doubleCalculator.Multiplication(5.8, 6.3));
            Console.WriteLine(doubleCalculator.Division(5.8, 6.3));
        }
    }
}