using BloggingSystem.DataLayer;
using BloggingSystem.Models;
using BloggingSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloggingSystem.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        public HttpResponseMessage GetPosts(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);

                 return this.Request.CreateResponse(HttpStatusCode.OK, context.Posts.OrderByDescending(p => p.Date));
             });

            return responseMsg;
        }

        public HttpResponseMessage GetPosts(int page, int count, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);

                 var postsOnPage = context.Posts
                            .OrderByDescending(p => p.Date)
                            .Skip(page * count)
                            .Take(count);

                 return this.Request.CreateResponse(HttpStatusCode.OK, postsOnPage);
             });

            return responseMsg;
        }

        public HttpResponseMessage GetPostsById(int id, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);

                 var post = context.Posts.FirstOrDefault(p => p.Id == id);

                 return this.Request.CreateResponse(HttpStatusCode.OK, post);
             });

            return responseMsg;
        }

        public HttpResponseMessage GetPostsByKeyword(string keyword, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);

                 var matchingPosts = (from p in context.Posts
                                      where p.Title.Contains(keyword)
                                      select p)
                                      .OrderBy(p => p.Date)
                                      .AsQueryable();

                 return this.Request.CreateResponse(HttpStatusCode.OK, matchingPosts);
             });

            return responseMsg;
        }

        public HttpResponseMessage GetPostsByTags(string tags, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);
                 var currTags = tags.Split(',');

                 var matchingPosts = (from p in context.Posts
                                      where currTags.Any(t => p.Title.Contains(t))
                                      select p)
                                      .OrderBy(p => p.Date)
                                      .AsQueryable();

                 return this.Request.CreateResponse(HttpStatusCode.OK, matchingPosts);
             });

            return responseMsg;
        }

        public HttpResponseMessage PostPosts(Post post, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 using (context)
                 {
                     var user = context.Users.FirstOrDefault(usr =>
                         usr.SessionKey == sessionKey);

                     if (user == null)
                     {
                         throw new InvalidOperationException("Invalid SessionKey!");
                     }

                     var newPost = new Post()
                     {
                         Id = post.Id,
                         Date = post.Date,
                         Title = post.Title,
                         Text = post.Text,
                         Tags = post.Tags,
                         Comments = post.Comments,
                         User = user
                     };

                     context.Posts.Add(newPost);
                     context.SaveChanges();

                     PostModel response = new PostModel()
                     {
                         Title = newPost.Title,
                         Id = newPost.Id
                     };

                     return this.Request.CreateResponse(HttpStatusCode.OK, response);
                 }
             });

            return responseMsg;
        }

        [ActionName("comment")]
        public HttpResponseMessage PutComment(int postId, [FromBody]Comment comment, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
             () =>
             {
                 var context = new BlogContext();
                 ValidateSessionKey(sessionKey, context);
                 using (context)
                 {
                     var currPost = context.Posts.FirstOrDefault(p => p.Id == postId);

                     if (currPost == null)
                     {
                         throw new InvalidOperationException("Post does not exist!");
                     }

                     Comment newComment = new Comment()
                     {
                         Id = comment.Id,
                         Date = comment.Date,
                         Post = comment.Post,
                         Text = comment.Text,
                         User = comment.User
                     };

                     currPost.Comments.Add(newComment);
                     context.Posts.Attach(currPost);
                     context.Entry(currPost).CurrentValues.SetValues(currPost);
                     context.SaveChanges();
                 }

                 return this.Request.CreateResponse(HttpStatusCode.Created);
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
