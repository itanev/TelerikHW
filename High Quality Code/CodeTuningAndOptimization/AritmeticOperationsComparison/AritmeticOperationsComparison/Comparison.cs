namespace AritmeticOperationsComparison
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    public class Comparison
    {
        public static void Main()
        {
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("\nInt:");
            PrintTimeForInt(100000, 100000, "add", stopWatch);
            PrintTimeForInt(100000, 100000, "subtract", stopWatch);
            PrintTimeForInt(100000, 100000, "multiply", stopWatch);
            PrintTimeForInt(100000, 100000, "devide", stopWatch);
            PrintTimeForInt(100000, 100000, "increment", stopWatch);
            Console.WriteLine("\nLong:");
            PrintTimeForLong(100000, 100000, "add", stopWatch);
            PrintTimeForLong(100000, 100000, "subtract", stopWatch);
            PrintTimeForLong(100000, 100000, "multiply", stopWatch);
            PrintTimeForLong(100000, 100000, "devide", stopWatch);
            PrintTimeForLong(100000, 100000, "increment", stopWatch);
            Console.WriteLine("\nFloat:");
            PrintTimeForFloat(100000, 100000, "add", stopWatch);
            PrintTimeForFloat(100000, 100000, "subtract", stopWatch);
            PrintTimeForFloat(100000, 100000, "multiply", stopWatch);
            PrintTimeForFloat(100000, 100000, "devide", stopWatch);
            PrintTimeForFloat(100000, 100000, "increment", stopWatch);
            Console.WriteLine("\nDouble:");
            PrintTimeForDouble(100000, 100000, "add", stopWatch);
            PrintTimeForDouble(100000, 100000, "subtract", stopWatch);
            PrintTimeForDouble(100000, 100000, "multiply", stopWatch);
            PrintTimeForDouble(100000, 100000, "devide", stopWatch);
            PrintTimeForDouble(100000, 100000, "increment", stopWatch);
            Console.WriteLine("\nDecimal:");
            PrintTimeForDecimal(100000, 100000, "add", stopWatch);
            PrintTimeForDecimal(100000, 100000, "subtract", stopWatch);
            PrintTimeForDecimal(100000, 100000, "multiply", stopWatch);
            PrintTimeForDecimal(100000, 100000, "devide", stopWatch);
            PrintTimeForDecimal(100000, 100000, "increment", stopWatch);
        }

        static void PrintTimeForInt(int firstInt, int secondInt, string action, Stopwatch stopWatch)
        {
            int result;

            switch (action)
            {
                case "add":
                    stopWatch.Start();
                    result = firstInt + secondInt;
                    stopWatch.Stop();
                    break;
                case "subtract":
                    stopWatch.Start();
                    result = firstInt - secondInt;
                    stopWatch.Stop();
                    break;
                case "multiply":
                    stopWatch.Start();
                    result = firstInt * secondInt;
                    stopWatch.Stop();
                    break;
                case "devide":
                    stopWatch.Start();
                    result = firstInt / secondInt;
                    stopWatch.Stop();
                    break;
                case "increment":
                    stopWatch.Start();
                    firstInt++;
                    stopWatch.Stop();
                    break;
            }

            Console.WriteLine("{0, -9} ints - {1}", action, stopWatch.Elapsed);
        }

        static void PrintTimeForLong(long firstInt, long secondInt, string action, Stopwatch stopWatch)
        {
            long result;

            switch (action)
            {
                case "add":
                    stopWatch.Start();
                    result = firstInt + secondInt;
                    stopWatch.Stop();
                    break;
                case "subtract":
                    stopWatch.Start();
                    result = firstInt - secondInt;
                    stopWatch.Stop();
                    break;
                case "multiply":
                    stopWatch.Start();
                    result = firstInt * secondInt;
                    stopWatch.Stop();
                    break;
                case "devide":
                    stopWatch.Start();
                    result = firstInt / secondInt;
                    stopWatch.Stop();
                    break;
                case "increment":
                    stopWatch.Start();
                    firstInt++;
                    stopWatch.Stop();
                    break;
            }

            Console.WriteLine("{0, -9} long - {1}", action, stopWatch.Elapsed);
        }

        static void PrintTimeForFloat(float firstInt, float secondInt, string action, Stopwatch stopWatch)
        {
            float result;

            switch (action)
            {
                case "add":
                    stopWatch.Start();
                    result = firstInt + secondInt;
                    stopWatch.Stop();
                    break;
                case "subtract":
                    stopWatch.Start();
                    result = firstInt - secondInt;
                    stopWatch.Stop();
                    break;
                case "multiply":
                    stopWatch.Start();
                    result = firstInt * secondInt;
                    stopWatch.Stop();
                    break;
                case "devide":
                    stopWatch.Start();
                    result = firstInt / secondInt;
                    stopWatch.Stop();
                    break;
                case "increment":
                    stopWatch.Start();
                    firstInt++;
                    stopWatch.Stop();
                    break;
            }

            Console.WriteLine("{0, -9} floats - {1}", action, stopWatch.Elapsed);
        }

        static void PrintTimeForDouble(double firstInt, double secondInt, string action, Stopwatch stopWatch)
        {
            double result;

            switch (action)
            {
                case "add":
                    stopWatch.Start();
                    result = firstInt + secondInt;
                    stopWatch.Stop();
                    break;
                case "subtract":
                    stopWatch.Start();
                    result = firstInt - secondInt;
                    stopWatch.Stop();
                    break;
                case "multiply":
                    stopWatch.Start();
                    result = firstInt * secondInt;
                    stopWatch.Stop();
                    break;
                case "devide":
                    stopWatch.Start();
                    result = firstInt / secondInt;
                    stopWatch.Stop();
                    break;
                case "increment":
                    stopWatch.Start();
                    firstInt++;
                    stopWatch.Stop();
                    break;
            }

            Console.WriteLine("{0, -9} doubles - {1}", action, stopWatch.Elapsed);
        }

        static void PrintTimeForDecimal(decimal firstInt, decimal secondInt, string action, Stopwatch stopWatch)
        {
            decimal result;

            switch (action)
            {
                case "add":
                    stopWatch.Start();
                    result = firstInt + secondInt;
                    stopWatch.Stop();
                    break;
                case "subtract":
                    stopWatch.Start();
                    result = firstInt - secondInt;
                    stopWatch.Stop();
                    break;
                case "multiply":
                    stopWatch.Start();
                    result = firstInt * secondInt;
                    stopWatch.Stop();
                    break;
                case "devide":
                    stopWatch.Start();
                    result = firstInt / secondInt;
                    stopWatch.Stop();
                    break;
                case "increment":
                    stopWatch.Start();
                    firstInt++;
                    stopWatch.Stop();
                    break;
            }

            Console.WriteLine("{0, -9} decimals - {1}", action, stopWatch.Elapsed);
        }
    }
}
