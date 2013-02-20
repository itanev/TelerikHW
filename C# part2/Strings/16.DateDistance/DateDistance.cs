using System;

class DateDistance
{
    static void Main()
    {
        int fDay, fMonth, fYear,
            sDay, sMonth, sYear;

        fDay = fMonth = fYear = sDay = sMonth = sYear = 0;

        //Enter first year
        EnterYear(ref fDay, ref fMonth, ref fYear);
        //Enter second year
        EnterYear(ref sDay, ref sMonth, ref sYear);
        
        //calculate the days between years
        DateTime FirstYear = new DateTime(fYear, fMonth, fDay);
        DateTime SecondYear = new DateTime(sYear, sMonth, sDay);
        TimeSpan span = SecondYear - FirstYear;

        //output the result
        Console.WriteLine("The span, in days, between dates is: {0}", span.Days);
    }

    static void EnterYear(ref int day, ref int month, ref int year)
    {
        Console.Write("Enter date in the format day.month.year: ");
        string date = Console.ReadLine();

        string[] dmy = date.Split('.');

        ValidateDate(dmy, ref day, ref month, ref year);
    }

    static void ValidateDate(string[] dmy, ref int day, ref int month, ref int year)
    {
        if (dmy.Length != 3)
        {
            Console.WriteLine("Invalid date!");
            return;
        }

        if (!int.TryParse(dmy[0], out day) || day < 1 || day > 31)
        {
            Console.WriteLine("Invalid day!");
        }
        else if (!int.TryParse(dmy[1], out month) || month < 1 || month > 12)
        {
            Console.WriteLine("Invalid month!");
        }
        else if (!int.TryParse(dmy[2], out year))
        {
            Console.WriteLine("Invalid year!");
        }
        else
        {
            if (DateTime.IsLeapYear(year) && month == 2 && day > 29)
            {
                Console.WriteLine("Invalid day!");
            }
            else if (!DateTime.IsLeapYear(year) && month == 2 && day > 28)
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}