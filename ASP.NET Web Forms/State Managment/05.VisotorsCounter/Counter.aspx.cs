using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace _05.VisotorsCounter
{
    public partial class Counter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            if (Application["Visitors"] == null)
            {
                Application["Visitors"] = 0;
            }
            Application.UnLock();

            Application.Lock();
            Application["Visitors"] = (int)Application["Visitors"] + 1;
            Application.UnLock();

            DrawString(Application["Visitors"].ToString());
        }

        private void DrawString(string stringToDraw)
        {
            Response.Clear();
            Response.ContentType = "image/jpeg";
            int height = 100;
            int width = 200;
            int x = 60;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.DrawString(stringToDraw, new Font("Arial", 52, FontStyle.Italic), Brushes.White, new PointF(x, 10));

            bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
            g.Dispose();
            bmp.Dispose();
            Response.End();
        }
    }
}