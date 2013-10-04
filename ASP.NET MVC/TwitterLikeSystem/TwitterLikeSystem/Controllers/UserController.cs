using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitterLikeSystem.Models;
using TwitterLikeSystem.Data;
using Microsoft.AspNet.Identity;

namespace TwitterLikeSystem.Controllers
{
   // [Authorize(Roles="user")]
    public class UserController : BaseController
    {
        private IUowData db = new UowData();
        private static ApplicationUser CurrUser { get; set; }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            CurrUser = db.Users.All().ToList().Find(x => x.Id == userId);

            var model = GetTweetsViewModel(CurrUser.Tweets.ToList()); 

            return View(model);
        }

        public ActionResult Tweet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = CurrUser.Tweets.ToList().Find(x => x.Id == (int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            var model = GetTweetViewModel(tweet);

            return View(model);
        }

        public ActionResult CreateTweet()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(TweetsViewModel tweet)
        {
            if (ModelState.IsValid)
            {
                var newTweet = GetTweetFromViewModel(tweet, User.Identity.Name, db);
                db.Tweets.Add(newTweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        public ActionResult EditTweet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = db.Tweets.All().ToList().Find(x => x.Id == (int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            var model = GetTweetViewModel(tweet);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTweet(TweetsViewModel tweet)
        {
            if (ModelState.IsValid)
            {
                var currTweet = GetTweetFromViewModel(tweet, User.Identity.Name, db);
                db.Tweets.Update(currTweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        public ActionResult DeleteTweet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tweet = db.Tweets.GetById((int)id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            var model = GetTweetViewModel(tweet);

            return View(model);
        }

        [HttpPost, ActionName("DeleteTweet")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Tweets.Delete(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
