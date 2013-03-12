using System;

namespace ShapesLib
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateSurface()
        {
            return this.width * this.height;
        }
    }
}
