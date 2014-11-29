namespace _2.Statistic
{
    using System;

    class Statistic
    {
        static void Main()
        {
            double[] arr = new double[] { 14, 9, 22, 13, 7, 4.9, 6 };

            PrintStatistics(arr, 6);
        }

        public static void PrintStatistics(double[] arr, int count)
        {
            double min = FindMinNumber(arr, count);
            Console.WriteLine("Min value = {0}".PadLeft(19, ' '), min);

            double max = FindMaxNumber(arr, count);
            Console.WriteLine("Max value = {0}".PadLeft(19, ' '), max);

            double average = FindAverageNumber(arr, count);
            Console.WriteLine("Average value = {0}", average);
        }

        // We keep 'count', because the user want to search only in the first several numbers he wants
        public static double FindMaxNumber(double[] arr, int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Count must be positive number, greather than 0!");
            }

            double max = double.MinValue;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        // We keep 'count', because the user want to search only in the first several numbers he wants
        public static double FindMinNumber(double[] arr, int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Count must be positive number, greather than 0!");
            }

            double min = double.MaxValue;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            return min;
        }

        // We keep 'count', because the user want to search only in the first several numbers he wants
        public static double FindAverageNumber(double[] arr, int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Count must be positive number, greather than 0!");
            }

            double sum = 0;
            double average = 0;

            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            average = sum / count;

            return average;
        }
    }
}
