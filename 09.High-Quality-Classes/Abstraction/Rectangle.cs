﻿using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle()
        {
            this.width = 0;
            this.height = 0;
        }

        public Rectangle(double width, double height)
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
                    throw new ArgumentException("Width must be positive");
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
                   throw new ArgumentException("Height must be positive"); 
                }

                this.height = value;
            }
        }


        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
