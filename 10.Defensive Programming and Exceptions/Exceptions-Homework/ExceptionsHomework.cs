using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("arr", "Array must be intialized!");
        }

        if (startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex", "Start index must be less than array's length!");
        }

        if (count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex", "Elements count must be less than array's length!");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex + count", "The sum of start index and count of elements exceed the array length!");
        }


        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex", "Symbols count must be less than string's length!");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "Symbols count must be positive integer number!");
        }

        if (str == null)
        {
            throw new ArgumentNullException("str", "String must be initialized!");
        }
        if (str == "")
        {
            throw new ArgumentException("String can't be empty!", "str");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        bool isPrime = true;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
            }
        }

        return isPrime;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        bool isPrime = CheckPrime(23);
        Console.WriteLine("23 is prime: {0}", isPrime);

        isPrime = CheckPrime(33);
        Console.WriteLine("33 is prime: {0}", isPrime);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
