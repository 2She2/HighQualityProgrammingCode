namespace CohesionAndCoupling
{
    using System;

    class _2DGeometryUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDiagonal(double width, double height)
        {
            double distance = Math.Sqrt((width * width) + (height * height));
            return distance;
        }
    }
}
