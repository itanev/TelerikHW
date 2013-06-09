using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountDoubles
{
    public class CountDoubles
    {
        public static void Main()
        {
            double[] numbers = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var numbersAndOccurrences = CountNumbers(numbers);

            foreach (var pair in numbersAndOccurrences)
            {
                Console.WriteLine("{0} -> {1} times.", pair.Key, pair.Value);
            }
        }
  
        private static Dictionary<double, double> CountNumbers(double[] numbers)
        {
            Dictionary<double, double> numbersAndOccurrences = new Dictionary<double, double>();
            foreach (var number in numbers)
            {
                if (numbersAndOccurrences.ContainsKey(number))
                {
                    numbersAndOccurrences[number] += 1;
                }
                else
                {
                    numbersAndOccurrences.Add(number, 1);
                }
            }

            return numbersAndOccurrences;
        }
    }
}
