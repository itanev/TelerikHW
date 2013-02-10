using System;
using System.Collections.Generic;

class WorkDays
{
    static void Main()
    {
        List<DateTime> holidays = new List<DateTime>();
        holidays.Add(new DateTime(2013, 1, 1));
        holidays.Add(new DateTime(2013, 5, 1));
        holidays.Add(new DateTime(2013, 5, 2));
        holidays.Add(new DateTime(2013, 5, 3));
        holidays.Add(new DateTime(2013, 5, 6));
        holidays.Add(new DateTime(2013, 5, 24));
        holidays.Add(new DateTime(2013, 8, 6));
        holidays.Add(new DateTime(2013, 11, 1));
        holidays.Add(new DateTime(2013, 12, 24));
        holidays.Add(new DateTime(2013, 12, 25));
        holidays.Add(new DateTime(2013, 12, 26));
        holidays.Add(new DateTime(2013, 12, 30));
        holidays.Add(new DateTime(2013, 12, 31));

        Console.WriteLine(CalculateWorkDays(new DateTime(2013, 6, 20), holidays));
    }

    static short CalculateWorkDays(DateTime day, List<DateTime> holidays)
    {
        int days = Math.Abs((day - DateTime.Now).Days);
        DateTime current = new DateTime();
        current = DateTime.Today;

        short workDays = 0;

        for (int i = 0; i < days; i++)
        {
            if (holidays.Contains(current.AddDays(i).Date))
            {
                continue;
            }

            if (current.AddDays(i).DayOfWeek == DayOfWeek.Saturday ||
                current.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
            {
                continue; 
            }
            workDays++;
        }
        return workDays;
    }
}
