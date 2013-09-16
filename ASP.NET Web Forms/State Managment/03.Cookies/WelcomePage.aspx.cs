using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Cookies
{
    public partial class WelcomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies.Get("loggedUser");
            if (cookie == null)
            {
                Response.Redirect("~/LoginPage.aspx");
            }

            welcomeLabel.Text = "Welcome " + cookie.Values["username"];
        }
    }
}