using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.Calc
{
    public partial class Calc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonSqrt.Text = "\u221A";
        }

        protected void ButtonNumber_Click(object sender, EventArgs e)
        {
            if (this.LabelNewNumber.Text == "false")
            {
                this.TextBoxInput.Text += ((Button)sender).Text;
            }
            else
            {
                if (this.LabelOperation.Text == "")
                {
                    this.LabelCurrentNumber.Text = "0";
                }
                else
                {
                    this.LabelCurrentNumber.Text = Server.HtmlEncode(TextBoxInput.Text);
                }
                this.TextBoxInput.Text = ((Button)sender).Text;
                this.LabelNewNumber.Text = "false";
            }
        }

        private void CalculateResultNumber()
        {
            this.LabelCalculate.Text = "false";
            double result;
            double storageResult;
            bool isstorageResult = double.TryParse(this.LabelCurrentNumber.Text, out storageResult);
            bool isResult = double.TryParse(this.TextBoxInput.Text, out result);
            if (isstorageResult && isResult)
            {
                switch (this.LabelOperation.Text)
                {
                    case "plus":
                        this.TextBoxInput.Text = Convert.ToString(storageResult + result);
                        break;
                    case "minus":
                        this.TextBoxInput.Text = Convert.ToString(storageResult - result);
                        break;
                    case "multiple":
                        this.TextBoxInput.Text = Convert.ToString(storageResult * result);
                        break;
                    case "divide":
                        this.TextBoxInput.Text = Convert.ToString(storageResult / result);
                        break;
                    case "sqrt":
                        this.TextBoxInput.Text = Convert.ToString(Math.Round(Math.Sqrt(result), 2));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.TextBoxInput.Text = "Error";
            }
        }

        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (this.LabelCalculate.Text == "true")
            {
                CalculateResultNumber();
            }

            this.LabelOperation.Text = "plus";
            this.LabelNewNumber.Text = "true";
            this.LabelCalculate.Text = "true";
        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (this.LabelCalculate.Text == "true")
            {
                CalculateResultNumber();
            }

            this.LabelOperation.Text = "minus";
            this.LabelNewNumber.Text = "true";
            this.LabelCalculate.Text = "true";
        }

        protected void ButtonMultiple_Click(object sender, EventArgs e)
        {
            if (this.LabelCalculate.Text == "true")
            {
                CalculateResultNumber();
            }

            this.LabelOperation.Text = "multiple";
            this.LabelNewNumber.Text = "true";
            this.LabelCalculate.Text = "true";
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            if (this.LabelCalculate.Text == "true")
            {
                CalculateResultNumber();
            }

            this.LabelOperation.Text = "divide";
            this.LabelNewNumber.Text = "true";
            this.LabelCalculate.Text = "true";
        }

        protected void ButtonSqrt_Click(object sender, EventArgs e)
        {
            this.LabelOperation.Text = "sqrt";
            CalculateResultNumber();
            this.LabelOperation.Text = "";
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.TextBoxInput.Text = "";
        }

        protected void ButtonResult_Click(object sender, EventArgs e)
        {
            CalculateResultNumber();
            this.LabelOperation.Text = "";
            this.LabelNewNumber.Text = "true";
            this.LabelCalculate.Text = "false";
        }
    }
}