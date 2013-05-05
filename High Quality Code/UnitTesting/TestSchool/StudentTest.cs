using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySchool;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitStudentWithoutSchool()
        {
            Student pesho = new Student("Pesho", 19345, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitStudentWithNullName()
        {
            School mySchool = new School();
            Student pesho = new Student(null, 19345, mySchool);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitStudentWithEmptyName()
        {
            School mySchool = new School();
            Student pesho = new Student("", 19345, mySchool);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitStudentWithTooSmallNumber()
        {
            School mySchool = new School();
            Student pesho = new Student("Pesho", 9999, mySchool);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitStudentWithTooBigNumber()
        {
            School mySchool = new School();
            Student pesho = new Student("Pesho", 100000, mySchool);
        }

        [TestMethod]
        public void InitStudent()
        {
            School mySchool = new School();
            Student pesho = new Student("Pesho", 10001, mySchool);

            Assert.IsTrue(pesho.Name == "Pesho");
            Assert.IsTrue(pesho.Number == 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JoinCourseOfNull()
        {
            School mySchool = new School();

            Student pesho = new Student("Pesho", 10000, mySchool);

            pesho.JointCourse(null);
        }

        [TestMethod]
        public void JoinCourse()
        {
            School mySchool = new School();

            Course math = new Course();

            Student pesho = new Student("Pesho", 10000, mySchool);

            pesho.JointCourse(math);

            Assert.IsTrue(math.Students.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LeaveCourseOfNull()
        {
            School mySchool = new School();

            Student pesho = new Student("Pesho", 99999, mySchool);

            pesho.LeaveCourse(null);
        }

        [TestMethod]
        public void LeaveCourse()
        {
            School mySchool = new School();

            Course math = new Course();

            Student pesho = new Student("Pesho", 10000, mySchool);
            Student gosho = new Student("Gosho", 10001, mySchool);

            pesho.JointCourse(math);
            gosho.JointCourse(math);

            pesho.LeaveCourse(math);

            Assert.IsTrue(math.Students.Count == 1);
        }
    }
}
