using System;

namespace ShapesLib
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.width = radius;
            this.height = radius;
        }

        //the same with width
        public override double CalculateSurface()
        {
            return this.height * this.height * Math.PI;    
        }
    }
}
