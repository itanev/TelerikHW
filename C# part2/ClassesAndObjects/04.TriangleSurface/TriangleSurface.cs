using System;

class TriangleSurface
{
    static void Main()
    {
        //int s = 5;
        //int altitude = 2;
        //Console.WriteLine( CalculateSurface(s, altitude) );

        //Console.WriteLine(CalculateSurface(4,3,6));

        Console.WriteLine(CalculateSurface(4, 8, 60));
    }

    static double CalculateSurface(int side, int alt)
    {
        return side * alt / 2;
    }

    static double CalculateSurface(params int[] sides)
    {
        int p = (sides[0] + sides[1] + sides[2]) / 2;
        return Math.Sqrt(p*(p-sides[0])*(p-sides[1])*(p-sides[2]));
    }

    static double CalculateSurface(int firstSide, int secondSide, int angleBetweenThem)
    {
        return firstSide * secondSide * Math.Sin(angleBetweenThem * Math.PI / 180) / 2; 
    }
}
