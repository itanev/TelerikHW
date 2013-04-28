namespace SortingAlgorithmsComparison
{
    using System;
    using System.Linq;
    using System.Diagnostics;

    public class Comparison
    {
        public static void Main()
        {
            int[] intArr = { 1,32,4,5,6,5,3,3,3,6 };
            double[] doubleArr = { 1,2,4.5, 6.4, 8, 9.1};
            string[] strArr = { "pesho", "gosho", "kiro", "ivan", "dragan", "roslan", "neshtositam" };

            int[] randomArr = new int[20];
            Random rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                randomArr[i] = rand.Next(1, 100);
            }

            int[] sortedArr = { 1,2,3,4,5,6,7,8,9,10 };
            int[] reversedArr = { 10,9,8,7,6,5,4,3,2,1 };

            Stopwatch stopWatch = new Stopwatch();

            //for int
            Console.WriteLine("Selection sort for ints:");
            stopWatch.Start();
            SelectionSort(intArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nInsertion sort for ints:");
            stopWatch.Start();
            InsertionSort(intArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nQuick sort for ints:");
            stopWatch.Start();
            Quicksort(intArr, 0, intArr.Length-1);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);
            Console.WriteLine(new string('#', 20));
            
            //for double
            Console.WriteLine("Selection sort for double:");
            stopWatch.Start();
            SelectionSort(doubleArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nInsertion sort for double:");
            stopWatch.Start();
            InsertionSort(doubleArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nQuick sort for double:");
            stopWatch.Start();
            Quicksort(doubleArr, 0, doubleArr.Length - 1);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);
            Console.WriteLine(new string('#', 20));

            //for string
            Console.WriteLine("Selection sort for strings:");
            stopWatch.Start();
            SelectionSort(strArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nInsertion sort for strings:");
            stopWatch.Start();
            InsertionSort(strArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nQuick sort for strings:");
            stopWatch.Start();
            Quicksort(strArr, 0, strArr.Length - 1);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);
            Console.WriteLine(new string('#', 20));

            //for random values
            Console.WriteLine("Selection sort for random ints:");
            stopWatch.Start();
            SelectionSort(randomArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nInsertion sort for random ints:");
            stopWatch.Start();
            InsertionSort(randomArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nQuick sort for random ints:");
            stopWatch.Start();
            Quicksort(randomArr, 0, randomArr.Length - 1);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);
            Console.WriteLine(new string('#', 20));

            //for sorted values
            Console.WriteLine("Selection sort for sorted ints:");
            stopWatch.Start();
            SelectionSort(sortedArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nInsertion sort for sorted ints:");
            stopWatch.Start();
            InsertionSort(sortedArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nQuick sort for sorted ints:");
            stopWatch.Start();
            Quicksort(sortedArr, 0, sortedArr.Length - 1);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);
            Console.WriteLine(new string('#', 20));

            //for reversed values
            Console.WriteLine("Selection sort for reversed ints:");
            stopWatch.Start();
            SelectionSort(reversedArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nInsertion sort for reversed ints:");
            stopWatch.Start();
            InsertionSort(reversedArr);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);

            Console.WriteLine("\nQuick sort for reversed ints:");
            stopWatch.Start();
            Quicksort(reversedArr, 0, reversedArr.Length - 1);
            stopWatch.Stop();
            Console.WriteLine("Time: {0}", stopWatch.Elapsed);
            Console.WriteLine(new string('#', 20));
        }

        public static void Quicksort(int[] arr, int left, int right)
        {
            int i = left, j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(arr, left, j);
            }

            if (i < right)
            {
                Quicksort(arr, i, right);
            }
        }

        public static void Quicksort(double[] arr, int left, int right)
        {
            int i = left, j = right;
            double pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    double tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(arr, left, j);
            }

            if (i < right)
            {
                Quicksort(arr, i, right);
            }
        }

        public static void Quicksort(string[] arr, int left, int right)
        {
            int i = left, j = right;
            string pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    string tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(arr, left, j);
            }

            if (i < right)
            {
                Quicksort(arr, i, right);
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int inner, temp;

            for (int outer = 1; outer <= arr.Length-1; outer++)
            {
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }

                arr[inner] = temp;
            }
        }

        public static void InsertionSort(double[] arr)
        {
            int inner;
            double temp;

            for (int outer = 1; outer <= arr.Length - 1; outer++)
            {
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }

                arr[inner] = temp;
            }
        }

        public static void InsertionSort(string[] arr)
        {
            int inner;
            string temp;

            for (int outer = 1; outer <= arr.Length - 1; outer++)
            {
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1].CompareTo(temp) >= 0)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }

                arr[inner] = temp;
            }
        }

        public static void SelectionSort(int[] arr)
        {
            int i, j;
            int min, temp;
 
            for( i = 0; i < arr.Length - 1; i++ )
            {
                min = i;
 
                for( j = i+1; j < arr.Length; j++ )
                {
                    if( arr[j] < arr[min] )
                    {
                        min = j;
                    }
                }
 
                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        public static void SelectionSort(double[] arr)
        {
            int i, j, min;
            double temp;

            for (i = 0; i < arr.Length - 1; i++)
            {
                min = i;

                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        public static void SelectionSort(string[] arr)
        {
            int i, j, min;
            string temp;

            for (i = 0; i < arr.Length - 1; i++)
            {
                min = i;

                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[min]) == -1)
                    {
                        min = j;
                    }
                }

                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
    }
}
