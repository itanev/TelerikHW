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

namespace TwitterLikeSystem.Controllers
{
    [Authorize(Roles="admin")]
    public class TweetsController : BaseController
    {
        private IUowData db = new UowData();

        public ActionResult Index()
        {
            var model = GetTweetsViewModel(db.Tweets.All().ToList());
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = db.Tweets.GetById((int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            var model = GetTweetViewModel(tweet);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TweetsViewModel tweet)
        {
            if (ModelState.IsValid)
            {
                var currTweet = GetTweetFromViewModel(tweet, User.Identity.Name, db);
                db.Tweets.Add(currTweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = db.Tweets.GetById((int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            var model = GetTweetViewModel(tweet);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TweetsViewModel tweet)
        {
            if (ModelState.IsValid)
            {
                var currTweet = GetTweetFromViewModel(tweet, User.Identity.Name ,db);
                db.Tweets.Update(currTweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        public ActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
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
