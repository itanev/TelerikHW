using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BiDictionary
{
    public class MainProgram
    {
        public static void Main()
        {
            BiDictionary<string, int, string> myDictionary = new BiDictionary<string, int, string>();

            myDictionary.Add("name", 1, "pesho");

            Console.WriteLine(myDictionary.Find(1));
            Console.WriteLine(myDictionary.Find("name"));
            Console.WriteLine(myDictionary.Find("name", 1));
            //throws exception when key not found.
            //Console.WriteLine(myDictionary.Find(34));
            //Console.WriteLine(myDictionary.Find("dsfs"));
        }
    }
}
