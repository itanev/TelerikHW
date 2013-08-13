using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicesLayer;
using ServicesLayer.Controllers;
using DataLayer;
using System.Transactions;

namespace ServicesLayer.Tests.Controllers
{
    [TestClass]
    public class StudentsControllerTest
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Get()
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            IEnumerable<Student> result = controller.Get();

            // Assert
            Student expectedStudent = new Student()
            {
                firstName = "pesho",
                lastName = "peshev",
                age = 20,
                grade = 5
            };

            var resultStudentAtOne = result.ElementAt(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(expectedStudent.firstName, resultStudentAtOne.firstName);
            Assert.AreEqual(expectedStudent.firstName, resultStudentAtOne.firstName);
            Assert.AreEqual(expectedStudent.lastName, resultStudentAtOne.lastName);
            Assert.AreEqual(expectedStudent.age, resultStudentAtOne.age);
            Assert.AreEqual(expectedStudent.grade, resultStudentAtOne.grade);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            Student result = controller.Get(3);

            // Assert
            Student expectedStudent = new Student()
            {
                firstName = "pesho",
                lastName = "peshev",
                age = 20,
                grade = 5
            };

            Assert.AreEqual(expectedStudent.firstName, result.firstName);
            Assert.AreEqual(expectedStudent.lastName, result.lastName);
            Assert.AreEqual(expectedStudent.age, result.age);
            Assert.AreEqual(expectedStudent.grade, result.grade);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            Student newStudent = new Student()
            {
                firstName = "kiro",
                lastName = "ivanov",
                age = 20,
                grade = 7
            };

            controller.Post(newStudent);

            // Assert
            var count = controller.Get().Count();
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            Student updatedStudent = new Student()
            {
                firstName = "stamat",
                lastName = "peshev",
                age = 20,
                grade = 5
            };

            controller.Put(2, updatedStudent);

            // Assert
            var theStudent = controller.Get(2);
            Assert.AreEqual(theStudent.firstName, updatedStudent.firstName);
            Assert.AreEqual(theStudent.lastName, updatedStudent.lastName);
            Assert.AreEqual(theStudent.age, updatedStudent.age);
            Assert.AreEqual(theStudent.grade, updatedStudent.grade);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            controller.Delete(2);

            // Assert
            var count = controller.Get().Count();
            Assert.AreEqual(1, count);
        }
    }
}
