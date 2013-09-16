using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Cookies
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendUserInfo_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = new HttpCookie("loggedUser");
            userCookie.Values.Add("username", Username.Text);
            userCookie.Values.Add("password", pass.Text);
            userCookie.Expires = DateTime.Now.AddMinutes(1.0);

            Response.Cookies.Add(userCookie);
            Response.Redirect("~/WelcomePage.aspx");
        }
    }
}