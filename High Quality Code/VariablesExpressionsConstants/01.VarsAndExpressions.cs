namespace VarsExpressionsConstants
{
    using System;
    using System.Linq;

    public class VarsAndExpressions
    {
        public static void Main()
        {
            //use functions here
        }

        public static Size GetRotatedSize(Size size, double angleOfRotation)
        {
            var angleSinus = Math.Abs(Math.Sin(angleOfRotation));
            var angleCosinus = Math.Abs(Math.Cos(angleOfRotation));

            var width = (angleCosinus * size.Width) + (angleSinus * size.Height);
            var height = (angleSinus * size.Width) + (angleCosinus * size.Height);

            return new Size(width, height);
        }
    }

    public class Size
    {
        private double width, height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width 
        {
            get 
            {
                return this.width;
            }

            set
            {
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
                this.height = value;
            }
        }
    }
}
