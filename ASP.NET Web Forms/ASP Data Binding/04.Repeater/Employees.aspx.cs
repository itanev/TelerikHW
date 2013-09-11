using _04.Repeater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.Repeater
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities entities = new NorthwindEntities();
            var employees = (from em in entities.Employees
                             select em).ToList();

            this.employees.DataSource = employees;
            this.DataBind();
        }
    }
}