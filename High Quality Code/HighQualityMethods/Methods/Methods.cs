namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToString(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, 'f');
            PrintAsNumber(0.75, '%');
            PrintAsNumber(2.30, 'r');

            double x1 = 3;
            double y1 = -1;
            double x2 = 3;
            double y2 = 2.5;

            Console.WriteLine(CalcDistance(x1, y1, x2, y2));

            bool isHorizontal = AreEqual(y1, y2);
            bool isVertical = AreEqual(y1, y2);

            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        private static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("The sides must be positive!");
            }

            // Calculates area using Herons formula.
            double p = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));

            return area;
        }

        private static string DigitToString(int digit)
        {
            string digitAsString = string.Empty;

            switch (digit)
            {
                case 0:
                    digitAsString = "zero";
                    break;
                case 1:
                    digitAsString = "one";
                    break;
                case 2:
                    digitAsString = "two";
                    break;
                case 3:
                    digitAsString = "three";
                    break;
                case 4:
                    digitAsString = "four";
                    break;
                case 5:
                    digitAsString = "five";
                    break;
                case 6:
                    digitAsString = "six";
                    break;
                case 7:
                    digitAsString = "seven";
                    break;
                case 8:
                    digitAsString = "eight";
                    break;
                case 9:
                    digitAsString = "nine";
                    break;
                default:
                    throw new ArgumentException("Invalid number!");
            }

            return digitAsString;
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                return -1;
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        private static void PrintAsNumber(double number, char format)
        {
            string formatedResult = string.Empty;

            switch (format)
            {
                case 'f':
                    formatedResult = string.Format("{0:f2}", number);
                    break;
                case '%':
                    formatedResult = string.Format("{0:p0}", number);
                    break;
                case 'r':
                    formatedResult = string.Format("{0,8}", number);
                    break;
                default:
                    throw new FormatException("Invalid format!");
            }

            Console.WriteLine(formatedResult);
        }

        private static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        private static bool AreEqual(double firstCoord, double secondCoord)
        {
            bool areEqual = false;

            if (firstCoord == secondCoord)
            {
                areEqual = true;
            }

            return areEqual;
        }
    }
}
