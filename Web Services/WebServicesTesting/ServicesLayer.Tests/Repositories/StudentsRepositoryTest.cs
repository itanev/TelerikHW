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
using RipositoriesLayer;


namespace ServicesLayer.Tests.Repositories
{
    [TestClass]
    public class StudentsRepositoryTest
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
            StudentsRepository repository = new StudentsRepository(new StudentsEntities());

            // Act
            IEnumerable<Student> result = repository.All();

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
            StudentsEntities context = new StudentsEntities();
            var repository = new StudentsRepository(context);

            // Act
            Student result = repository.Get(3);

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
            var repository = new StudentsRepository(new StudentsEntities());

            // Act
            Student newStudent = new Student()
            {
                firstName = "kiro",
                lastName = "ivanov",
                age = 20,
                grade = 7
            };

            repository.Add(newStudent);

            // Assert
            var count = repository.All().Count();
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            var repository = new StudentsRepository(new StudentsEntities());

            // Act
            Student updatedStudent = new Student()
            {
                firstName = "stamat",
                lastName = "peshev",
                age = 20,
                grade = 5
            };

            repository.Update(2, updatedStudent);

            // Assert
            var theStudent = repository.Get(2);
            Assert.AreEqual(theStudent.firstName, updatedStudent.firstName);
            Assert.AreEqual(theStudent.lastName, updatedStudent.lastName);
            Assert.AreEqual(theStudent.age, updatedStudent.age);
            Assert.AreEqual(theStudent.grade, updatedStudent.grade);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var repository = new StudentsRepository(new StudentsEntities());

            // Act
            repository.Delete(2);

            // Assert
            var count = repository.All().Count();
            Assert.AreEqual(1, count);
        }
    }
}
