using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Linq;

namespace LibrarySystem.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RegisterHyperLink.NavigateUrl = "Register";
                OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

                var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
                }
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
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    // Validate the user password
                    if (IdentityConfig.Secrets.Validate(UserName.Text, Password.Text))
                    {
                        string localUserId = IdentityConfig.Logins.GetUserId(IdentityConfig.LocalLoginProvider, UserName.Text);
                        if (localUserId != null)
                        {
                            Context.SignIn(localUserId, new Claim[] { }, RememberMe.Checked);
                            IdentityConfig.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        };
                    }
                    else
                    {
                        FailureText.Text = "Your login attempt was not successful. Please try again.";
                        ErrorMessage.Visible = true;
                    }
                }
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
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }
    }
}