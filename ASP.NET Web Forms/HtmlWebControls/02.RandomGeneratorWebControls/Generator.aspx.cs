using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.RandomGeneratorWebControls
{
    public partial class Generator : System.Web.UI.Page
    {
        protected void Generate(object sender, EventArgs e)
        {
            var firstNum = int.Parse(this.firstNum.Text);
            var secondNum = int.Parse(this.secondNum.Text);

            var min = Math.Min(firstNum, secondNum);
            var max = Math.Max(firstNum, secondNum);

            Random rand = new Random();
            var num = rand.Next(min, max);

            this.res.Text = num.ToString();
        }
    }
}