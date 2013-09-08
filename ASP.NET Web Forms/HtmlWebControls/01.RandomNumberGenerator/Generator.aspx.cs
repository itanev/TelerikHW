using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.RandomNumberGenerator
{
    public partial class Generator : System.Web.UI.Page
    {
        protected void GenerateHandler(object sender, EventArgs e)
        {
            var firstNum = int.Parse(this.bottomBorder.Value);
            var secondNum = int.Parse(this.topBorder.Value);
            var min = Math.Min(firstNum, secondNum);
            var max = Math.Max(firstNum, secondNum);
            Random rand = new Random();
            var num = rand.Next(min, max);

            this.res.Value = num.ToString();
        }
    }
}