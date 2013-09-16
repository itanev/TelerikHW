using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.ClientInformation
{
    public partial class ClientInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpBrowserCapabilities bc = Request.Browser;
            this.BrowserType.Text = Request.UserAgent;
            this.IP.Text = Request.UserHostAddress;
        }
    }
}