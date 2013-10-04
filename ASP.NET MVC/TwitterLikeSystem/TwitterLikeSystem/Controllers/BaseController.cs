using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterLikeSystem.Models;
using TwitterLikeSystem.Data;

namespace TwitterLikeSystem.Controllers
{
    public class BaseController : Controller
    {
        protected IEnumerable<TweetsViewModel> GetTweetsViewModel(List<Tweet> allTweets)
        {
            var model = from t in allTweets
                        select new TweetsViewModel
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Content = t.Content,
                            ByUser = t.User.UserName
                        };

            return model;
        }

        protected TweetsViewModel GetTweetViewModel(Tweet tweet)
        {
            var model = new TweetsViewModel()
            {
                Id = tweet.Id,
                Title = tweet.Title,
                Content = tweet.Content,
                ByUser = tweet.User.UserName
            };

            return model;
        }

        protected Tweet GetTweetFromViewModel(TweetsViewModel tweet, string username, IUowData db)
        {
            // Security risk...
            var tweetUser = db.Users.All().ToList().Find(x => x.UserName == username);
            Tweet result = new Tweet()
            {
                Id = tweet.Id,
                Content = tweet.Content,
                Title = tweet.Title,
                User = tweetUser
            };

            return result;
        }
    }
}