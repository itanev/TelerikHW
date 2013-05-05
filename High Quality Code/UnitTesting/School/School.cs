using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    public class School
    {
        private List<Course> courses;
        private List<int> studentsNumbers;

        public School()
        {
            this.Courses = new List<Course>();
            this.studentsNumbers = new List<int>();
        }

        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of courses can not be null!");
                }

                this.courses = value;
            }
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null!");
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course can not be null!");
            }

            this.courses.Remove(course);
        }

        // This is kind of a helper method for ensuaring that every student has an unique number.
        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student can not be null!");
            }

            MakeSureStudentNumberIsUnique(student);

            this.studentsNumbers.Add(student.Number);
        }
  
        private void MakeSureStudentNumberIsUnique(Student student)
        {
            for (int numIndex = 0; numIndex < this.studentsNumbers.Count; numIndex++)
            {
                if (this.studentsNumbers[numIndex] == student.Number)
                {
                    throw new ArgumentException("The student is already part of the school!");
                }
            }
        }
    }
}
