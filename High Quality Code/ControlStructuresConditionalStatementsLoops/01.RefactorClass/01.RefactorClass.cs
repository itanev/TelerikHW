namespace _01.RefactorClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RefactorClass
    {
        public static void Main()
        {
            Chef pesho;
            pesho.Cook();
        }
    }

    public class Chef
    {
        public Potato CurrentPotato { get; private set; }

        public Carrot CurrentCarrot { get; private set; }

        public Peel CurrentPeel { get; private set; }

        public List<Vegetable> Bowl { get; private set; }

        public void Cook()
        {
            this.AddToSalad(this.CurrentPotato);
            this.AddToSalad(this.CurrentCarrot);
        }

        private void AddToSalad(Vegetable currentVegetable)
        {
            Peel(currentVegetable);
            Cut(currentVegetable);
            Bowl.Add(currentVegetable);
        }

        private void Cut(Vegetable currentVegetable)
        {
            //...
        }
    }
}
