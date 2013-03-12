using System;
using Exceptions;

class TestException
{
    static void Main()
    {
        InvalidRangeException<int> customIntExcepton = 
            new InvalidRangeException<int>("Invalid range!", 1, 100);

        InvalidRangeException<DateTime> customDateTimeExcepton = new InvalidRangeException<DateTime>
        (
            "Invalid range!", 
            new DateTime(1980, 1, 1),
            new DateTime(2013, 12, 31)
        );

        try
        {
            EnterNumber();
            EnterDate();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    //test for integer
    static void EnterNumber()
    {
        Console.WriteLine("Enter integer: ");

        int a = int.Parse(Console.ReadLine());

        if (a < 1 || a > 100)
        {
            throw new InvalidRangeException<int>("Invalid range! The number must be between 1 and 100.", 100, 1);
        }

        Console.WriteLine("The number is {0}", a);
    }

    //test for datetime
    static void EnterDate()
    {
        int year, month, day;

        Console.WriteLine("Enter year: ");
        year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter month: ");
        month = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter day: ");
        day = int.Parse(Console.ReadLine());

        DateTime date = new DateTime(year, month, day);

        if( (date.CompareTo(new DateTime(1980, 1, 1))) < 0 || 
            (date.CompareTo(new DateTime(2013, 12, 31))) > 0)
        {
            throw new InvalidRangeException<DateTime>("Inavalid range exception! The date must beteween 1.1.1980 and 31.12.2013",
                new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
        }

        Console.WriteLine("The date you enter is valid!");
    }
}