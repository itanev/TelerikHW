using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Escaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void ShowText(object sender, EventArgs e)
        {
            this.txt.Text = Server.HtmlEncode(this.txtBox.Text);
        }
    }
}