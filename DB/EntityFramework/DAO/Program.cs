using System;
using System.Collections.Generic;
using System.Linq;

namespace DAOClass
{
    class Program
    {
        static void Main()
        {
            //DAO.InsertCustomer("ACBI", "test", "test", "test", "test", "test", "test", "test", "test", "test", "test");
            //DAO.ModifyCustomer("ACBI", new Tuple<string, string>("city", "Sofia"));
            DAO.DeleteCustomer("ACBI");
        }
    }
}
