using System;
using Library03;

class TestAnimals
{
    static void Main()
    {
        //cats
        Cat[] cats = 
        { 
            new Tomcat(10, "Kiro"),
            new Kitten(5, "Mimi"),
            new Cat(5, "Joro", "male"),
            new Tomcat(3, "Pesho"),
            new Kitten(4, "Penka")
        };

        Console.WriteLine("Cats");
        Console.WriteLine( AverageAge(cats) );

        //frogs
        Frog[] frogs = 
        {
            new Frog(10, "Kiro", "male"),
            new Frog(5, "Mimi", "female"),
            new Frog(5, "Joro", "male"),
            new Frog(3, "Pesho", "male"),
            new Frog(4, "Penka", "female")
        };

        Console.WriteLine("\nFrogs");
        Console.WriteLine( AverageAge(frogs) );

        //dogs
        Dog[] dogs = 
        {
            new Dog(10, "Kiro", "male"),
            new Dog(5, "Mimi", "female"),
            new Dog(5, "Joro", "male"),
            new Dog(3, "Pesho", "male"),
            new Dog(4, "Penka", "female")
        };

        Console.WriteLine("\nDogs");
        Console.WriteLine(AverageAge(dogs));
    }

    //the method for calculating average age of any kind of animal
    static double AverageAge(Animal[] listAnimals)
    {
        double avg = 0;

        foreach (var animal in listAnimals)
        {
            avg += animal.Age;
        }

        return avg / listAnimals.Length;
    }
}
