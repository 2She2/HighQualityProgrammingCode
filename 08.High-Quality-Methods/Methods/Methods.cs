namespace Methods
{
    using System;

    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0)
            {
                throw new ArgumentException("Side \"a\" must be positive number, greather than 0");
            }

            if (b <= 0)
            {
                throw new ArgumentException("Side \"b\" must be positive number, greather than 0");
            }

            if (c <= 0)
            {
                throw new ArgumentException("Side \"c\" must be positive number, greather than 0");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        static string ConvertDigitToWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Input must be a digit. Range is from 0 to 9");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Array is not set to instance!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Array must have at least one element!");
            }

            int max = int.MinValue;

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }
            return max;
        }

        public static void PrintNumber(double value, int decimals)
        {
            string format = "{0:F" + decimals + "}";
            Console.WriteLine(format, value);
        }

        public static void PrintPercent(double value, int decimals)
        {
            string format = "{0:P" + decimals + "}";
            Console.WriteLine(format, value);
        }

        public static void PrintAligned(object value, int totalWidth)
        {
            string format = "{0," + totalWidth + "}";
            Console.WriteLine(format, value);
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        static bool CheckIsLineHorizontal(double y1, double y2)
        {
            bool isHorizontal = false;

            if (y1 == y2)
            {
                isHorizontal = true;
            }

            return isHorizontal;
        }

        static bool CheckIsLineVertical(double x1, double x2)
        {
            bool isVertical = false;

            if (x1 == x2)
            {
                isVertical = true;
            }

            return isVertical;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumber(1.3, 2);
            PrintPercent(0.75, 1);
            PrintAligned(2.30, 10);

            bool isHorizontal = CheckIsLineHorizontal(-1, 2.5);
            bool isVertical = CheckIsLineVertical(3, 3);
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", dateOfBirth = new DateTime(1992, 03, 17) };
            peter.OtherInfo = "From Sofia";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova", dateOfBirth = new DateTime(1993, 11, 03) };
            stella.OtherInfo = "From Vidin, gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
