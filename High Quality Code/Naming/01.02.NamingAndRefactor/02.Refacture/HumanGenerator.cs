namespace _02.Refacture
{
    using System;
    using System.Linq;

    public class HumanGenerator
    {
        public void CreateHuman(int age)
        {
            Human human = new Human();

            human.Age = age;

            if (age % 2 == 0)
            {
                human.Name = "Пешо";
                human.Sex = Gender.Male;
            }
            else
            {
                human.Name = "Мария";
                human.Sex = Gender.Female;
            }
        }
    }
}
