using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Posts.Models;
using Posts.Context;

namespace Posts.Services.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage PostCategory(Category category)
        {
            var dbContext = new PostsContext();
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public HttpResponseMessage GetCategory()
        {
            var dbContext = new PostsContext();
            var categories = dbContext.Categories.AsQueryable();

            return this.Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        [HttpGet]
        [ActionName("posts")]
        public HttpResponseMessage GetPostsByCategory(int categoryId)
        {
            var dbContext = new PostsContext();

            var postsByCategory = (from p in dbContext.Posts
                                   where p.Category.Id == categoryId
                                   select p).AsQueryable();

            return this.Request.CreateResponse(HttpStatusCode.OK, postsByCategory);
        }
    }
}
