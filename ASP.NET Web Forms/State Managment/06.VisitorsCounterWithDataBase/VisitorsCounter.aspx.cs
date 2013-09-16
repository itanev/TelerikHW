using _06.VisitorsCounterWithDataBase.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.VisitorsCounterWithDataBase
{
    public partial class VisitorsCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisitorsCountEntities db = new VisitorsCountEntities();
            var counter = db.Visitors.FirstOrDefault();

            if (counter == null)
            {
                db.Visitors.Add(new Visitors()
                {
                    id = 0,
                    count = 0
                });
            }
            else
            {
                counter.count++;
            }

            db.SaveChanges();

            DrawString(db.Visitors.First().count.ToString());
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