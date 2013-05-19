using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public interface IProduct
    {
        string Name {get; set;}
        string Sell();
        string Buy();
    }
}
