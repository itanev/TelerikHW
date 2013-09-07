using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.WebApps
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void SumHandler(object sender, EventArgs e)
        {
            var res = int.Parse(this.firstNum.Text) + int.Parse(this.secondNum.Text);
            this.result.Text = res.ToString();
        }
    }
}