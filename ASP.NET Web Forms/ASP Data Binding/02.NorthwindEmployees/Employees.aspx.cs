using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _02.NorthwindEmployees.Models;

namespace _02.NorthwindEmployees
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities entities = new NorthwindEntities();
            var employees = (from em in entities.Employees
                            select new 
                            { 
                                Id = em.EmployeeID, 
                                Name = em.FirstName + " " + em.LastName 
                            }).ToList();

            this.Employess.DataSource = employees;
            this.DataBind();
        }
    }
}