using System;

class NeighboursCheck
{
    static void Main()
    {
        int[] a = { 10, 4,5,6,7,4,3,4,6,8,54,3,3};
        Console.WriteLine(CheckNeighbours(a, 3));
    }

    static bool CheckNeighbours(int[] a, int position)
    {
        if (position <= 0 || position >= a.Length - 1)
        {
            //because it doesn't have two neighbours
            return false;
        }
        else
        {
            if (a[position] > a[position - 1] && a[position] > a[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
}
