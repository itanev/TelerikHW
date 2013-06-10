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
            myHashTable.Add("Ivan", 20);

            myHashTable["Gosho"] = 12;
            myHashTable["Stamat"] = 12;

            Console.WriteLine(myHashTable["Ivan"]);

            // Problem with foreach
            foreach (var item in myHashTable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
