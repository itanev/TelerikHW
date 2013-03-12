using System;
using ShapesLib;

class TestShapes
{
    static void Main()
    {
        Shape[] shapes = 
        {
            new Triangle(4,5),
            new Rectangle(4,5),
            new Circle(4)
        };

        Console.WriteLine("Cirface of the triangle is: {0}", shapes[0].CalculateSurface());
        Console.WriteLine("Cirface of the rectangle is: {0}", shapes[1].CalculateSurface());
        Console.WriteLine("Cirface of the circle is: {0:F2}", shapes[2].CalculateSurface());
    }
}
