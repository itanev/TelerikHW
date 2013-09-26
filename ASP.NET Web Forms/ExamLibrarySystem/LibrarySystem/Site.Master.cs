using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;
using System.Linq;

namespace LibrarySystem
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                // The code below helps to protect against XSRF attacks
                var requestCookie = Request.Cookies[AntiXsrfTokenKey];
                Guid requestCookieGuidValue;
                if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
                {
                    // Use the Anti-XSRF token from the cookie
                    _antiXsrfTokenValue = requestCookie.Value;
                    Page.ViewStateUserKey = _antiXsrfTokenValue;
                }
                else
                {
                    // Generate a new Anti-XSRF token and save to the cookie
                    _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                    Page.ViewStateUserKey = _antiXsrfTokenValue;

                    var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                    {
                        HttpOnly = true,
                        Value = _antiXsrfTokenValue
                    };
                    if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                    {
                        responseCookie.Secure = true;
                    }
                    Response.Cookies.Set(responseCookie);
                }

                Page.PreLoad += master_Page_PreLoad;
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                ErrorSuccessNotifier.AddErrorMessage(exceptionMessage + " " + ex.EntityValidationErrors);
            }
            catch(Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // Set Anti-XSRF token
                    ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                    ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
                }
                else
                {
                    // Validate the Anti-XSRF token
                    if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                        || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                    {
                        throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    this.catBtn.Visible = true;
                    this.booksBtn.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            try
            {
                Context.SignOut();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }
    }

}