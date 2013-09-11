using _03.NorthwindEmployeesFormView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.NorthwindEmployees
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities entities = new NorthwindEntities();
            var currId = int.Parse(Request.QueryString["id"]);
            var employee = (from em in entities.Employees
                             where currId == em.EmployeeID
                             select em).ToList();

            if (employee != null)
            {
                this.Details.DataSource = employee;
                this.DataBind();
            }
        }
    }
}