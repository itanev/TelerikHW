namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle()
        {
            this.Radius = 0;
        }

        public Circle(double radius) 
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid radius! Value must be positive.");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
