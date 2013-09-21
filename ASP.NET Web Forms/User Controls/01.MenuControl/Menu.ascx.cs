using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace _01.MenuControl
{
    public partial class Menu : System.Web.UI.UserControl
    {
        public List<Item> Items { get; set; }

        public string Font { get; set; }
        public string FontColor { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Items = new List<Item>()
            {
                new Item() 
                {
                    Name = "Link1",
                    Url = "http://www.someurl.com"
                },
                new Item() 
                {
                    Name = "Link2",
                    Url = "http://www.someurl.com"
                },
                new Item() 
                {
                    Name = "Link3",
                    Url = "http://www.someurl.com"
                },
                new Item() 
                {
                    Name = "Link4",
                    Url = "http://www.someurl.com"
                }
            };

            this.menu.DataSource = this.Items;
            this.menu.DataBind();

            this.menu.Font.Name = this.Font;
            this.menu.ForeColor = Color.FromName(this.FontColor);
        }
    }
}