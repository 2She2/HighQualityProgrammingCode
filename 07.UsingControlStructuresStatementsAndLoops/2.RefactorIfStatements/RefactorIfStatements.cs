namespace _2.RefactorIfStatements
{
    using _1.Chef;
    using System;

    class RefactorIfStatements
    {
        static void Main()
        {
            const int MIN_X = 0;
            const int MAX_X = 0;
            const int MIN_Y = 0;
            const int MAX_Y = 0;
            
            int x = 0;
            int y = 0;

            bool shouldVisitCell = true;

            bool isXInRange = MIN_X <= x && x <= MAX_X;
            bool isYInRange = MIN_Y <= y && y <= MAX_Y;

            if (isXInRange && isYInRange && shouldVisitCell)
            {
                VisitCell();
            }


            // Reference to exercise 1 is added
            Potato potato = new Potato();

            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                    Cook(potato);
            }
        }

        public static void VisitCell()
        {
            Console.WriteLine("Cell visited!");
        }

        public static void Cook(Vegetable vegetable)
        {
            Console.WriteLine("Cooking");
        }
    }
}
