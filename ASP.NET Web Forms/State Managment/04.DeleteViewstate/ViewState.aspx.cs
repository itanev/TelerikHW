using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.DeleteViewstate
{
    public partial class ViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var scriptToDeleteViewState = "document.getElementById('__VIEWSTATE').remove();";
            ClientScript.RegisterStartupScript(this.GetType(), "deleteViewstate", scriptToDeleteViewState, true);
        }
    }
}