using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RipositoriesLayer;
using Telerik.JustMock;

namespace ServicesLayer.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenOneCategory_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepsitory<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                firstName = "bai",
                lastName = "ivan",
                age = 20,
                grade = 5
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
