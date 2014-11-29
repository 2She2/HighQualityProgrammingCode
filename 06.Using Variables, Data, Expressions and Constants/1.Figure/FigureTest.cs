namespace _1.Figure
{
    using System;

    class FigureTest
    {
        static void Main()
        {
            double rectangleWidth = 3;
            double rectangleHeight = 7;
            double degreesToRotate = 90;

            Figure rectangle = new Figure(rectangleWidth, rectangleHeight);
            PrintFigureDimensions(rectangle);

            Figure rotatedRectangle = Figure.GetRotatedFigure(rectangle, degreesToRotate);
            PrintFigureDimensions(rotatedRectangle);
        }

        public static void PrintFigureDimensions(Figure figure)
        {
            Console.WriteLine("Figure width is: {0:F2}".PadLeft(24, ' '), figure.Width);
            Console.WriteLine("Figure height is: {0:F2}", figure.Height);
        }
    }
}
