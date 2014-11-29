using System;
using System.Linq;

public class ComparePerformanceOfMathFunctions
{
    private const int NumberOfOperations = 100000;

    static void CalculateSquareRoot()
    {
        Console.Write("Square root of float:   ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            float result = 1000000f;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = (float)Math.Sqrt(result);
            }
        });

        Console.Write("Square root of double:  ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            double result = 1000000.0;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = Math.Sqrt(result);
            }
        });

        Console.Write("Square root of decimal: ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            decimal result = 1000000m;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = (decimal)Math.Sqrt((double)result);
            }
        });
    }

    static void CalculateNaturalLogarithm()
    {
        Console.Write("Natural logarithm of float:   ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            float result = 1000000f;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = (float)Math.Log(result, Math.E);
            }
        });

        Console.Write("Natural logarithm of double:  ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            double result = 1000000.0;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = Math.Log(result, Math.E);
            }
        });

        Console.Write("Natural logarithm of decimal: ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            decimal result = 1000000m;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                //This method cause overflow
                //result = (decimal)Math.Log((double)result, Math.E);
            }
        });
    }

    static void CalculateSinus()
    {
        Console.Write("Sinus of float:   ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            float result = 1000000f;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = (float)Math.Sin(result);
            }
        });

        Console.Write("Sinus of double:  ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            double result = 1000000.0;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = Math.Sin(result);
            }
        });

        Console.Write("Sinus of decimal: ");
        ComparePreformanceOfAritmeticOperations.DisplayExecutionTime(() =>
        {
            decimal result = 1000000m;
            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = (decimal)Math.Sin((double)result);
            }
        });
    }

    static void Main()
    {
        Console.WriteLine("All values are in Milliseconds!\n");

        CalculateSquareRoot();
        Console.WriteLine();

        CalculateNaturalLogarithm();
        Console.WriteLine();

        CalculateSinus();
    }
}
