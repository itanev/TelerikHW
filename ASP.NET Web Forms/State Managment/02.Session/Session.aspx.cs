using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Session
{
    public partial class Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendToSession_Click(object sender, EventArgs e)
        {
            Session.Contents.Add(Session.Contents.Count.ToString(), this.Content.Text);
        }

        protected void PrintSession_Click(object sender, EventArgs e)
        {
            List<string> sessionLines = new List<string>();
            foreach (var item in Session.Contents)
            {
                sessionLines.Add(Session.Contents[item.ToString()].ToString());
            }

            this.SessionContent.Text = string.Join("<br />", sessionLines);
        }
    }
}