using System;
using System.Linq;

namespace DayAsStringService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IDayAsStringService
    {
        public string GetDayAsString(DateTime date)
        {
            string day = string.Empty;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    day = "Monday";
                    break;
                case DayOfWeek.Tuesday:
                    day = "Tuesday";
                    break;
                case DayOfWeek.Wednesday:
                    day = "Wednesday";
                    break;
                case DayOfWeek.Thursday:
                    day = "Thursday";
                    break;
                case DayOfWeek.Friday:
                    day = "Friday";
                    break;
                case DayOfWeek.Sunday:
                    day = "Sunday";
                    break;
                case DayOfWeek.Saturday:
                    day = "Saturday";
                    break;
            }

            return day;
        }
    }
}
