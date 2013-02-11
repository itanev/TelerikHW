using System;

class PrintNewDateAndTime
{
    static void Main()
    {
        Console.Write("Enter date in the the format d.m.y h:m:s: ");
        string fullDate = Console.ReadLine();

        //withouth validation because the code will become too long 
        //the validation is the same as the prev ex
        string[] parts = fullDate.Split(' ');
        string[] date = parts[0].Split('.');
        string[] time = parts[1].Split(':');

        int day = int.Parse(date[0]);
        int month = int.Parse(date[1]);
        int year = int.Parse(date[2]);

        int hours = int.Parse(time[0]);
        int minutes = int.Parse(time[1]);
        int seconds = int.Parse(time[2]);

        System.Globalization.CultureInfo cultureInfo =
        new System.Globalization.CultureInfo("bg-BG");

        //27.1.2013 21:21:43
        DateTime result = new DateTime(year, month, day, hours, minutes, seconds);
        Console.WriteLine(result.AddHours(6.5));
        Console.WriteLine(result.AddHours(6.5).DayOfWeek);
    }
}
