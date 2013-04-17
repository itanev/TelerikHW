namespace _02.RefactorIf
{
    using System;
    using System.Linq;

    public class RefactorIf
    {
        public static void Main()
        {
            // First if. Cooking potato.
            Potato potato;
            // ... 
            if (potato != null)
            {
                if (!potato.IsRotten && potato.HasBeenPeeled)
                {
                    Cook(potato);
                }
            }

            // Second if. I change it a little bit. Because the given logic doesn't seem right.
            if (shouldVisitCell && IsInRange(x, MAX_X, MIN_X) && IsInRange(y, MAX_Y, MIN_Y))
            {
               VisitCell();
            }
        }

        public static bool IsInRange(int coordinate, int topBoundary, int bottomBoundary)
        {
            bool inRange = false;

            if (coordinate >= bottomBoundary && coordinate <= topBoundary)
            {
                inRange = true;
            }

            return inRange;
        }
    }
}
