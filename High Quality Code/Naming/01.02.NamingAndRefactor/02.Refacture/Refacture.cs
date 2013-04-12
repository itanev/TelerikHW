namespace _02.Refacture
{
    using System;
    using System.Linq;

    public class Refacture
    {
        public static void Main()
        {
            HumanGenerator human = new HumanGenerator();

            human.CreateHuman(20);
        }
    }
}
