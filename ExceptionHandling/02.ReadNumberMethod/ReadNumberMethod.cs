using System;

class ReadNumberMethod
{
    static void Main()
    {
        int start = 1;
        int end = 100;

        while (true)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    ReadNumber(start, end);
                }
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You must enter something.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number in range [{0}..{1}]", start, end);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number overflows the type int");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }

    static void ReadNumber(int start, int end)
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        if (n < start || n > end)
        {
            throw new FormatException();
        }
    }
}