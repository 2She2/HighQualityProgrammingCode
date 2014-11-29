namespace NamingIdentifiers
{
    using System;

    public class ConsolePrinter
    {
        // There are two ways to name constants
        // const int MAX_COUNT = 6
        const int MaxCount = 6;

        public class BoolPrinter
        {
            public void PrintBoolAsString(bool value)
            {
                string boolAsString = value.ToString();

                Console.WriteLine(boolAsString);
            }
        }
        public static void Main()
        {
            ConsolePrinter.BoolPrinter boolPrinter = new ConsolePrinter.BoolPrinter();
            boolPrinter.PrintBoolAsString(true);
        }
    }

}
