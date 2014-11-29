namespace Matrix
{
    using System;

    public class WalkInMatrix
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int length;

            while (!int.TryParse(input, out length) || !ValidateLength(length))
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            Matrix matrix = new Matrix(length);
            matrix.FillMatrix();
            Console.WriteLine(matrix.ToString());
        }

        private static bool ValidateLength(int length)
        {
            if (length < 0 || length > 100)
            {
                return false;
            }

            return true;
        }
    }
}
