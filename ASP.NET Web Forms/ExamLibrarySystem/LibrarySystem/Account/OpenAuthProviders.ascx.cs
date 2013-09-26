using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data.Entity.Validation;
using Error_Handler_Control;

namespace LibrarySystem.Account
{
    public partial class OpenAuthProviders : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    var provider = Request.Form["provider"];
                    if (provider == null)
                    {
                        return;
                    }
                    // Request a redirect to the external login provider
                    Context.Challenge(new string[] { provider }, new AuthenticationExtra() { RedirectUrl = "/Account/RegisterExternalLogin?providerName=" + provider });
                    Response.StatusCode = 401;
                    Response.End();
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

        public string ReturnUrl { get; set; }

        public IEnumerable<string> GetProviderNames()
        {
            return Context.GetExternalAuthenticationTypes().Select(t => t.Properties["AuthenticationType"].ToString());
        }
    }
}