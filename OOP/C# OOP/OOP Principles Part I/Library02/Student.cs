using System;

namespace Library02
{
    public class Student : Human
    {
        private float grade;

        //grade property
        public float Grade 
        {
            get
            {
                return this.grade;
            }
            set
            {
                this.grade = value;
            }
        }

        public Student(string firstName, string lastName, float grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }
}
