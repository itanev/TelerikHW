using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterLikeSystem.Data;
using TwitterLikeSystem.Models;
using Microsoft.AspNet.Identity;

namespace TwitterLikeSystem.Controllers
{
    public class HomeController : BaseController
    {
        private IUowData db = new UowData();
        public ActionResult Index()
        {
            var allTweets = db.Tweets.All().ToList();
            var model = GetTweetsViewModel(allTweets);

            return View(model);
        }

        public ActionResult UserTweets()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.All().ToList().Find(x => x.Id == userId);
            var userTweets = GetTweetsViewModel(user.Tweets.ToList());

            return View("Index", userTweets);
        }

        [ActionName("Search")]
        [OutputCache(Duration=15*60)]
        public ActionResult SearchByTag(string tagName)
        {
            var result = from t in db.Tweets.All()
                         where t.Content.Contains(tagName) || t.Title.Contains(tagName)
                         select t;

            var model = GetTweetsViewModel(result.ToList());

            return View("Search", model);
        }
    }
}