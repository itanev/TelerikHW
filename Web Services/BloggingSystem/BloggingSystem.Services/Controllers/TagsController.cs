using BloggingSystem.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloggingSystem.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        public HttpResponseMessage GetTags(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);

                 var allTags = (from t in context.Tags
                                select new
                                {
                                    t.Id,
                                    t.Name,
                                    t.Posts.Count
                                })
                               .OrderByDescending(t => t.Id)
                               .AsQueryable();

                 return this.Request.CreateResponse(HttpStatusCode.OK, allTags);
             });

            return responseMsg;
        }

        [ActionName("posts")]
        public HttpResponseMessage GetPostsForTag(int tagId, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);

                 var allPosts = (from t in context.Tags
                                 where t.Id == tagId
                                 select t)
                                .FirstOrDefault()
                                .Posts
                                .OrderByDescending(p => p.Date)
                                .AsQueryable();

                 return this.Request.CreateResponse(HttpStatusCode.OK, allPosts);
             });

            return responseMsg;
        }

        private void ValidateSessionKey(string sessionKey, BlogContext context)
        {
            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid SessionKey!");
            }
        }
    }
}
