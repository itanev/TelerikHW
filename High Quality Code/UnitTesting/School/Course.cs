using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    public class Course
    {
        private List<Student> students;
        private const int MaxStudents = 30;

        public Course()
        {
            this.students = new List<Student>();
        }

        public Course(List<Student> students)
        {
            this.Students = students;
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of students can not be null!");
                }

                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (MaxStudents != this.students.Count)
            {
                this.students.Add(student);
            }
            else
            {
                throw new ArgumentOutOfRangeException("There can not be more than 30 students in the course!");
            }
        }

        public void RemoveStudent(Student student)
        {
            if (this.students.Contains(student))
            {
                this.students.Remove(student);
            }
            else
            {
                throw new ArgumentException("The student is already in the course!");
            }
        }
    }
}
