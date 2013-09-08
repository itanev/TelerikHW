using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _04.StudentRegistration
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Submit(object sender, EventArgs e)
        {
            var newLine = new HtmlGenericControl("br");

            var name = new HtmlGenericControl("h1");
            name.InnerHtml = Server.HtmlEncode(this.firstName.Text + " " + this.lastName.Text);

            var facNum = new HtmlGenericControl("p");
            facNum.InnerHtml = Server.HtmlEncode("№" + this.facultyNum.Text);

            var uni = new HtmlGenericControl("h2");
            uni.InnerHtml = Server.HtmlEncode(this.uni.SelectedItem.Text);

            var speciality = new HtmlGenericControl("h2");
            speciality.InnerHtml = Server.HtmlEncode(this.speciality.SelectedItem.Text);

            var courses = new HtmlGenericControl("p");
            var selectedCourses = string.Empty;
            foreach (var index in this.courses.GetSelectedIndices())
            {
                var course = this.courses.Items[index].Text;
                selectedCourses += course + ',';
            }

            courses.InnerHtml = Server.HtmlEncode(selectedCourses);

            this.contentArea.Controls.Add(name);
            this.contentArea.Controls.Add(newLine);
            this.contentArea.Controls.Add(facNum);
            this.contentArea.Controls.Add(newLine);
            this.contentArea.Controls.Add(uni);
            this.contentArea.Controls.Add(newLine);
            this.contentArea.Controls.Add(speciality);            
            this.contentArea.Controls.Add(newLine);
            this.contentArea.Controls.Add(courses);
        }
    }
}