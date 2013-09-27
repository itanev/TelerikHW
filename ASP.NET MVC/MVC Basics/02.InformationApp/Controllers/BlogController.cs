using _02.InformationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.InformationApp.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        [ActionName("Posts")]
        public ActionResult GetAllPosts()
        {
            ViewBag.AllPosts = GetPosts(5);
            return View("AllPosts");
        }

        private List<Post> GetPosts(int numberPostsToGenerate)
        {
            var posts = new List<Post>();

            for (int i = 0; i < numberPostsToGenerate; i++)
            {
                posts.Add
                (
                    new Post
                    {
                        Id = i,
                        Title = string.Format("Company post {0}", i),
                        Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                    }
                );
            }
            
            return posts;
        }
    }
}