using System;
using Library;
using System.Collections.Generic;

class PointIn3D
{
    static void Main()
    {
        //ex 01
        Point3D myPoint = new Point3D(1,2,3);

        Console.WriteLine(myPoint.ToString());

        //ex 02
        Console.WriteLine(Point3D.GetZeroPoint());

        //ex 03
        Point3D myOtherPoint = new Point3D(4,8,6);
        Console.WriteLine(Distance.CalculateDistance(myPoint, myOtherPoint));

        //ex 04
        Path holder = new Path();

        holder.points.Add(myPoint);
        holder.points.Add(myOtherPoint);

        PathStorage.SavePaths(holder, "points.txt");
        PathStorage.LoadPaths("points.txt");
    }
}
