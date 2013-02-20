using System;

class SortStringsByLength
{
    static void Main()
    {
        Console.Write("Length: ");
        int n = int.Parse(Console.ReadLine());

        string[] strs = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("el({0}) = ");
            strs[i] = Console.ReadLine();
        }

        //sort by strings length - bubble sort
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int k = i; k < n; k++)
            {
                count = k+1;
                if (count < n && strs[i].Length > strs[count].Length)
                {
                    swap(ref strs[i], ref strs[count]);
                    count++;
                }
            }
        }

        //print the strings
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(strs[i]);
        }
    }

    static void swap(ref string str1, ref string str2)
    {
        string temp = str1;
        str1 = str2;
        str2 = temp;
    }
}

