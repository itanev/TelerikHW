using System;

class SquareRoot
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter number: ");
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new FormatException();
                }
                double sqrt = Math.Sqrt(n);
                Console.WriteLine("Sqrt({0}) = {1}", n, sqrt);
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You must enter something.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number of type int.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number overflows the type int.");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}