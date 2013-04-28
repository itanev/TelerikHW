namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileExtensionUtils.GetFileExtension("example"));
            Console.WriteLine(FileExtensionUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensionUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Utils2D.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Utils3D.CalcDistance3D(5, 2, -1, 3, -6, 4));

            double width = 3;
            double height = 4;
            double depth = 5;

            Console.WriteLine("Volume = {0:f2}", PropertiesUtils.CalcVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils3D.CalcDiagonalXYZ(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", Utils2D.CalcDiagonalXY(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils2D.CalcDiagonalXZ(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils2D.CalcDiagonalYZ(height, depth));
        }
    }
}
