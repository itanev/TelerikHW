using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Collections.Generic;
using BloggingSystem.Services.Controllers;
using BloggingSystem.Services.Models;
using System.Web.Http;
using System.Net;
using Newtonsoft.Json;
using BloggingSystem.Models;

namespace BloggingSystem.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                "PostsByTagApi",
                "api/tags/{tagId}/posts",
                new
                {
                    controller = "tags",
                    action = "posts"
                }
            ),

            new Route(
                "CommentsApi",
                "api/posts/{postId}/comment",
                new
                {
                    controller = "posts",
                    action = "comment"
                }
            ),

            new Route(
                "PostsApi",
                "api/posts",
                new
                {
                    controller = "posts"
                }
            ),

            new Route(
                "UsersApi",
                "api/users/{action}",
                new
                {
                    controller = "users"
                }
            ),

            new Route(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            )
            };

            this.httpServer = new InMemoryHttpServer("http://localhost:1418/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var model = RegisterOrLoginTestUser("api/users/register", httpServer, testUser);
            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void Logout()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var model = RegisterOrLoginTestUser("api/users/register", httpServer, testUser);
            var response = httpServer.Put("api/users/logout?sessionKey=" + model.SessionKey);
            var contentString = response.Content.ReadAsStringAsync().Result;
        }

        [TestMethod]
        public void Login_WhenUserModelValid_ReturnNickAndSessionKey()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            RegisterOrLoginTestUser("api/users/register", httpServer, testUser);
            var model = this.RegisterOrLoginTestUser("api/users/login", httpServer, testUser);

            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }

        //[TestMethod]
        //public void CreatePost()
        //{
        //    var testPost = new Post()
        //    {
        //        Title = "test post",
        //        Text = "test post content"
        //    };

        //    var testUser = new UserModel()
        //    {
        //        Username = "VALIDUSER",
        //        Nickname = "VALIDNICK",
        //        AuthCode = new string('b', 40)
        //    };

        //    var userModel = RegisterOrLoginTestUser("api/users/register", httpServer, testUser);

        //    var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, testPost);
        //    var contentString = response.Content.ReadAsStringAsync().Result;
        //    var postModel = JsonConvert.DeserializeObject<PostModel>(contentString);

        //    Assert.AreEqual(testPost.Title, postModel.Title);
        //    Assert.AreEqual(testPost.Id, postModel.Id);
        //}

        private LoggedUserModel RegisterOrLoginTestUser(string requestUrl, InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post(requestUrl, testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
