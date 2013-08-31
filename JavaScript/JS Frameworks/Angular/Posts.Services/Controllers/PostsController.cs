using Posts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Posts.Context;

namespace Posts.Services.Controllers
{
    public class PostsController : ApiController
    {
        [HttpPost]
        [ActionName("posts")]
        public HttpResponseMessage CreatePost(Post post)
        {
            var dbContext = new PostsContext();

            if (post.Category != null)
            {
                var postCat = dbContext.Categories.FirstOrDefault(c => c.Name == post.Category.Name);

                if (postCat != null)
                {
                    post.Category = postCat;
                }
            }

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [ActionName("posts")]
        public HttpResponseMessage GetPost()
        {
            var dbContext = new PostsContext();
            var posts = dbContext.Posts.AsQueryable();

            return this.Request.CreateResponse(HttpStatusCode.OK, posts);
        }
    }
}
