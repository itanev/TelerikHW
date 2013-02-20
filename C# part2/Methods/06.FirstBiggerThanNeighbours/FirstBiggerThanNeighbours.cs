using System;

class FirstBiggerThanNeighbours
{
    static void Main()
    {
        int[] a = { 4,5,5,34,7,6,7,8,5,54,4,45,65,6};
        Console.WriteLine(FindBigger(a));
    }

    static int FindBigger(int[] a)
    {
        for (int i = 1; i < a.Length-2; i++)
        {
            if (a[i] > a[i - 1] && a[i] > a[i + 1])
            {
                return i;
            }
        }

        return -1;
    }
}