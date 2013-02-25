using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Distance
    {
        //calculate distance using the pythagorean dependencies
        public static double CalculateDistance(Point3D point1, Point3D point2)
        {
            return Math.Sqrt((point1.x - point2.x) * (point1.x - point2.x) +
                             (point1.y - point2.y) * (point1.y - point2.y) +
                             (point1.z - point2.z) * (point1.z - point2.z));          
        }
    }
}
