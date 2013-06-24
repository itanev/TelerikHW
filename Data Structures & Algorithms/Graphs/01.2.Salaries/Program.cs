using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2.Salaries
{
    class Program
    {
        static List<int>[] list;
        static bool[] proccessed;
        static int[] salaries;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 50)
            {
                return;
            }

            list = new List<int>[n];
            proccessed = new bool[n];
            salaries = new int[n];

            for (int row = 0; row < n; row++)
            {
                var letter = Console.ReadLine();
                list[row] = new List<int>();
                for (int col = 0; col < n; col++)
			    {
                    if (letter[col] != 'N')
                    {
                        list[row].Add(col);
                    }
			    }
            }

            var sum = 0;
            for (int i = 0; i < list.Length; i++)
            {
                sum += SalarySum(i);   
            }

            Console.WriteLine(sum);
        }

        static int SalarySum(int currEmployee)
        {
            if (list[currEmployee].Count == 0)
            {
                return 1;
            }

            if (proccessed[currEmployee])
            {
                return salaries[currEmployee];
            }

            var salary = 0;
            for (int i = 0; i < list[currEmployee].Count; i++)
            {
                salary += SalarySum(list[currEmployee][i]);
            }

            proccessed[currEmployee] = true;
            salaries[currEmployee] = salary;

            return salary;
        }
    }
}
