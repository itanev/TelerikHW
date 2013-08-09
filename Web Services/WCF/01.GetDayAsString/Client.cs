using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using DayAsStringService;

namespace _01.GetDayAsString
{
    class Client
    {
        static void Main()
        {
            Service dayAsString = new Service();
            var result = dayAsString.GetDayAsString(DateTime.Now);

            Console.WriteLine(result);
        }
    }
}
