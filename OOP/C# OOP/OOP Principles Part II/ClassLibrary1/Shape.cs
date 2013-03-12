using System;

namespace ShapesLib
{
    public abstract class Shape
    {
        internal double width;
        internal double height;

        public abstract double CalculateSurface();
    }
}
