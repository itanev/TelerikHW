using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.CodeBehind
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.title.InnerText = "Hello, ASP.NET";
            this.location.InnerText = Assembly.GetExecutingAssembly().CodeBase;
        }
    }
}