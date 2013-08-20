using BloggingSystem.DataLayer;
using BloggingSystem.Models;
using BloggingSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace BloggingSystem.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNicknameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        public UsersController()
        {
        }

        /*
        {  "username": "DonchoMinkov",
           "nickname": "Doncho Minkov",
           "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }
        */

        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BlogContext();
                    using (context)
                    {
                        this.ValidateStr(model.Username, ValidUsernameCharacters, "User");
                        this.ValidateStr(model.Nickname, ValidNicknameCharacters, "Nickname");
                        this.ValidateAuthCode(model.AuthCode);
                        var usernameToLower = model.Username.ToLower();
                        var nicknameToLower = model.Nickname.ToLower();
                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username == usernameToLower
                            || usr.Nickname.ToLower() == nicknameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("Users exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            Nickname = model.Nickname,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            Nickname = user.Nickname,
                            SessionKey = user.AuthCode
                        };

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                        return response;
                    }
                });

            return responseMsg;
        }

        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new BlogContext();
                  using (context)
                  {
                      this.ValidateStr(model.Username, ValidUsernameCharacters, "User");
                      this.ValidateAuthCode(model.AuthCode);
                      var usernameToLower = model.Username.ToLower();
                      var user = context.Users.FirstOrDefault(
                          usr => usr.Username == usernameToLower
                          && usr.AuthCode == model.AuthCode);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid username or password");
                      }

                      if (user.SessionKey == null)
                      {
                          user.SessionKey = this.GenerateSessionKey(user.Id);
                          context.SaveChanges();
                      }

                      var loggedModel = new LoggedUserModel()
                      {
                          Nickname = user.Nickname,
                          SessionKey = user.SessionKey
                      };

                      var response =
                          this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                      return response;
                  }
              });

            return responseMsg;
        }

        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new BlogContext();

                  using (context)
                  {
                      ValidateSessionKey(sessionKey);
                      var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid SessionKey!");
                      }

                      user.SessionKey = null;
                      context.Users.Attach(user);
                      var entity = context.Entry(user);
                      entity.Property(e => e.SessionKey).IsModified = true;
                      context.SaveChanges();
                  }

                  return this.Request.CreateResponse(HttpStatusCode.OK);
              });

            return responseMsg;
        }

        private void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException("SessionKey can not be null!");
            }
            else if (sessionKey.Length < SessionKeyLength)
            {
                throw new ArgumentOutOfRangeException("SessionKey must be at least" + SessionKeyLength + " characters logn!");
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateStr(string strToValidate, string validChars, string nameInError)
        {
            if (strToValidate == null)
            {
                throw new ArgumentNullException(nameInError + " cannot be null");
            }
            else if (strToValidate.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(nameInError + " must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (strToValidate.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(nameInError + " must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (strToValidate.Any(ch => !validChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    nameInError + " must contain only Latin letters, digits .,_");
            }
        }
    }
}
