using System;

namespace ShapesLib
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateSurface()
        {
            return this.width * this.height / 2;
        }
    }
}
