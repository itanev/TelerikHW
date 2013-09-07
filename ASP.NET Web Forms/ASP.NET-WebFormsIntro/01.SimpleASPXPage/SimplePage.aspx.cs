using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.SimpleASPXPage
{
    public partial class SimplePage : System.Web.UI.Page
    {
        protected void SubmitHandler(object sender, EventArgs e)
        {
            this.theName.Text = this.nameHolder.Text;
        }
    }
}