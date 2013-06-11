using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTable
{
    public class MainProgram
    {
        static void Main()
        {
            HashTable<string, int> myHashTable = new HashTable<string, int>();

            myHashTable.Add("Pesho", 10);
            myHashTable.Add("Ivan1", 20);
            myHashTable.Add("Ivan2", 20);
            myHashTable.Add("Ivan3", 20);
            myHashTable.Add("Ivan4", 20);
            myHashTable.Add("Ivan5", 20);
            myHashTable.Add("Ivan6", 20);
            myHashTable.Add("Ivan7", 20);
            myHashTable.Add("Ivan8", 20);
            myHashTable.Add("Ivan9", 20);
            myHashTable.Add("Ivan10", 20);
            myHashTable.Add("Ivan11", 20);
            myHashTable.Add("Ivan12", 20);
            myHashTable.Add("Ivan13", 20);
            myHashTable.Add("Ivan14", 20);
            myHashTable.Add("Ivan15", 20);
            myHashTable.Add("Ivan16", 20);
            myHashTable.Add("Ivan17", 20);
            myHashTable.Add("Ivan18", 20);
            myHashTable.Add("Ivan19", 21);

            myHashTable["Gosho"] = 12;
            myHashTable["Stamat"] = 12;

            Console.WriteLine(myHashTable["Ivan19"]);

            // Problem with foreach
            //foreach (var item in myHashTable)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
