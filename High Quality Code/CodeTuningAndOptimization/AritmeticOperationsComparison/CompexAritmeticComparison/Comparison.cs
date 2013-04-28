namespace CompexAritmeticComparison
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    public class Comparison
    {
        public static void Main()
        {
            Stopwatch stopWatch = new Stopwatch();

            float fVal = 100;
            double dVal = 100;
            decimal mVal = 100;

            SQRT(stopWatch, fVal, dVal, mVal);
            LOG(stopWatch, fVal, dVal, mVal);
            SIN(stopWatch, fVal, dVal, mVal);
        }
  
        private static void SQRT(Stopwatch stopWatch, float fVal, double dVal, decimal mVal)
        {
            Console.WriteLine("SQRT:");
            stopWatch.Start();
            Math.Sqrt(fVal);
            stopWatch.Stop();

            Console.WriteLine("Float: {0, 19}", stopWatch.Elapsed);

            stopWatch.Start();
            Math.Sqrt(dVal);
            stopWatch.Stop();

            Console.WriteLine("Double: {0, 18}", stopWatch.Elapsed);

            stopWatch.Start();
            Math.Sqrt((double)mVal);
            stopWatch.Stop();

            Console.WriteLine("Decimal: {0, 17}\n", stopWatch.Elapsed);
        }

        private static void LOG(Stopwatch stopWatch, float fVal, double dVal, decimal mVal)
        {
            Console.WriteLine("LOG:");
            stopWatch.Start();
            Math.Log(fVal);
            stopWatch.Stop();

            Console.WriteLine("Float: {0, 19}", stopWatch.Elapsed);

            stopWatch.Start();
            Math.Log(dVal);
            stopWatch.Stop();

            Console.WriteLine("Double: {0, 18}", stopWatch.Elapsed);

            stopWatch.Start();
            Math.Log((double)mVal);
            stopWatch.Stop();

            Console.WriteLine("Decimal: {0, 17}\n", stopWatch.Elapsed);
        }

        private static void SIN(Stopwatch stopWatch, float fVal, double dVal, decimal mVal)
        {
            Console.WriteLine("SIN:");
            stopWatch.Start();
            Math.Sin(fVal);
            stopWatch.Stop();

            Console.WriteLine("Float: {0, 19}", stopWatch.Elapsed);

            stopWatch.Start();
            Math.Sin(dVal);
            stopWatch.Stop();

            Console.WriteLine("Double: {0, 18}", stopWatch.Elapsed);

            stopWatch.Start();
            Math.Sin((double)mVal);
            stopWatch.Stop();

            Console.WriteLine("Decimal: {0, 17}\n", stopWatch.Elapsed);
        }
    }
}
