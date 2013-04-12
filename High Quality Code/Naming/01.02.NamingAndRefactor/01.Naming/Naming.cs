namespace _01.Naming
{
    using System;
    using System.Linq;

    // Not in separate file, so it could be easier for check.
    public class Bool
    {
        public void Print(bool value)
        {
            string valueToString = value.ToString();

            Console.WriteLine(valueToString);
        }
    }

    public class Naming
    {
        private const int MAX_COUNT = 6;
        
        public static void Main()
        {
            Bool boolValue = new Bool();

            boolValue.Print(true);
        }
    }
}
