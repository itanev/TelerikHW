using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySchool;
using System.Collections.Generic;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void InitSchool()
        {
            School mySchool = new School();

            Assert.IsTrue(mySchool.Courses.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCourse()
        {
            School mySchool = new School();

            mySchool.AddCourse(null);
        }

        [TestMethod]
        public void AddCourse()
        {
            School mySchool = new School();

            mySchool.AddCourse(new Course());
            mySchool.AddCourse(new Course());

            Assert.IsTrue(mySchool.Courses.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullCourse()
        {
            School mySchool = new School();

            mySchool.RemoveCourse(null);
        }


        [TestMethod]
        public void RemoveCourse()
        {
            School mySchool = new School();

            Course math = new Course();
            Course OOP = new Course();

            mySchool.AddCourse(math);
            mySchool.AddCourse(OOP);

            mySchool.RemoveCourse(math);

            Assert.IsTrue(mySchool.Courses.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullStudent()
        {
            School mySchool = new School();

            mySchool.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentsWithIdenticalNumbers()
        {
            School mySchool = new School();

            mySchool.AddStudent(new Student("Pesho", 10004, mySchool));
            mySchool.AddStudent(new Student("Pesho", 10004, mySchool));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudents()
        {
            School mySchool = new School();

            mySchool.AddStudent(new Student("Pesho", 10004, mySchool));
            mySchool.AddStudent(new Student("Pesho", 10005, mySchool));
        }
    }
}
