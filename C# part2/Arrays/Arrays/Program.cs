using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[20] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        for (byte i = 0; i < 20; i++ )
        {
            arr[i] = i * 5;
            Console.WriteLine(arr[i]);
        }
    }
}

