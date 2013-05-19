using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class FactoryMethod
    {
        static void Main()
        {
            IProduct PC = new PCCreator("PC").Create();

            string pcState = PC.Buy();
            Console.WriteLine(pcState);

            pcState = PC.Sell();
            Console.WriteLine(pcState);
        }
    }
}
