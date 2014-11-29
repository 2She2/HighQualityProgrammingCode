namespace _1.Figure
{
    using System;

    public class Figure
    {
        private double width = 0;
        private double height = 0;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be positive!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be positive!");
                }

                this.height = value;
            }
        }

        public static Figure GetRotatedFigure(Figure figure, double angleOfRotation)
        {
            double rotatedFigureWidth = Math.Abs(Math.Cos(angleOfRotation)) * figure.width +
                (Math.Abs(Math.Sin(angleOfRotation)) * figure.Height);

            double rotatedFigureHeight = Math.Abs(Math.Sin(angleOfRotation)) * figure.width +
                (Math.Abs(Math.Cos(angleOfRotation)) * figure.Height);

            Figure rotatedFigure = new Figure(rotatedFigureWidth, rotatedFigureHeight);

            return rotatedFigure;
        }
    }
}
