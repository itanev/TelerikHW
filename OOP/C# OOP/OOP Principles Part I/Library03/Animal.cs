using System;

namespace Library03
{
    public class Animal : ISound
    {
        private double age;
        private string name;
        private string sex;

        //property for age
        public double Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        //property for name
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        //property for sex
        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        //method for producing sound
        public void ProduceSound(string sound)
        {
            Console.WriteLine(sound);
        }
    }
}
