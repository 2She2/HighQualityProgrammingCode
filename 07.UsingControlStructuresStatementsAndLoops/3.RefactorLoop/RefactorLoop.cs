namespace _3.RefactorLoop
{
    using System;

    class RefactorLoop
    {
        static void Main()
        {
            int[] array = new int[100];
            int expectedValue = 666; // It's not necessary to be 666 :)

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);

                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                    }
                }
            }
        }
    }
}
