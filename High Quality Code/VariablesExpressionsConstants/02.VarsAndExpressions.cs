namespace _02.VarsAndExpressions
{
    using System;
    using System.Linq;

    public class VarsAndExpressions
    {
        static void Main()
        {
            //use functions
        }

        public void PrintStatistics(double[] array)
        {
            var count = array.Length;

            double max = 0;

            for (int i = 0; i < count; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            PrintValue(max);

            double min = 0;

            for (int i = 0; i < count; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            PrintValue(min);

            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += array[i];
            }

            PrintAvg(sum, count);
        }

        private void PrintAvg(double sum, int count)
        {
            var average = sum / count;

            PrintValue(average);
        }

        private void PrintValue(double value)
        {
            Console.WriteLine(value);
        }
    }
}
