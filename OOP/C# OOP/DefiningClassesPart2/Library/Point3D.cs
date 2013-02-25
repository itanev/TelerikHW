using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public struct Point3D
    {
        //fields
        public int x;
        public int y;
        public int z;

        //the start of the coordinate system
        private static readonly int startX = 0;
        private static readonly int startY = 0;
        private static readonly int startZ = 0;

        //defining point
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //static method to return the start of the coordinate system
        public static Point3D GetZeroPoint()
        {
            return new Point3D(startX, startY, startZ);
        }

        //custom ToString()
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("Point X = {0}\n", this.x);
            output.AppendFormat("Point Y = {0}\n", this.y);
            output.AppendFormat("Point Z = {0}\n", this.z);

            return output.ToString();
        }
    }
}
