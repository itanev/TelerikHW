using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    public class Student
    {
        private string name;
        private int number = 9999;
        private const int MinNumber = 10000;
        private const int MaxNumber = 99999;

        public Student(string name, int number, School school)
        {
            if (school == null)
            {
                throw new ArgumentNullException("You must provide a school!");
            }

            this.Name = name;
            this.Number = number;
            school.AddStudent(this);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name can not be null!");
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("The name can not be empty!");
                }

                this.name = value;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }

            private set
            {
                if (value < MinNumber || value > MaxNumber)
                {
                    throw new ArgumentOutOfRangeException("The number must be between 10000 and 99999!");
                }

                this.number = value;
            }
        }

        public void JointCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("You must provide a course!");
            }

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("You must provide a course!");
            }

            course.RemoveStudent(this);
        }
    }
}
