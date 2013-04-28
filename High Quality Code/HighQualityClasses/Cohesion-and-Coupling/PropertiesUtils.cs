namespace CohesionAndCoupling
{
    using System;
    using System.Linq;

    public static class PropertiesUtils
    {
        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }
    }
}
