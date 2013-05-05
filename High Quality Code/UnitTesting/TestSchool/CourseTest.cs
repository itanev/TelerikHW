using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySchool;
using System.Collections.Generic;

namespace TestSchool
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitCourseNull()
        {
            Course math = new Course(null);
        }

        [TestMethod]
        public void InitCourseWithNoList()
        {
            Course math = new Course();
            Assert.IsTrue(math.Students.Count == 0);
        }

        [TestMethod]
        public void InitCourseWithList()
        {
            School mySchool = new School();

            List<Student> students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("pesho", 10000 + i, mySchool));
            }

            Course math = new Course(students);

            Assert.IsTrue(math.Students.Count == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaxNumberStudentsInCourse()
        {
            School mySchool = new School();
            Course math = new Course();

            for (int i = 0; i < 31; i++)
            {
                math.AddStudent(new Student("Pesho", 10000 + i, mySchool));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryingToRemoveUnexistingStudent()
        {
            School mySchool = new School();
            Course math = new Course();

            for (int i = 0; i < 30; i++)
            {
                math.AddStudent(new Student("Pesho", 10000 + i, mySchool));
            }

            math.RemoveStudent(new Student("Gosho", 34322, mySchool));
        }
    }
}
