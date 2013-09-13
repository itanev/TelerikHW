using _04.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.TodoList
{
    public partial class Todos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertTodo(object sender, EventArgs e)
        {
            Control control = DataGridTodos.FooterRow;

            if (control == null)
            {
                control = DataGridTodos.Controls[0].Controls[0];
            }

            var title = (control.FindControl("TodoTitle") as TextBox).Text;
            var categoryName = (control.FindControl("TodoCategory") as TextBox).Text;
            var body = (control.FindControl("TodoBody") as TextBox).Text;

            TodoListEntities db = new TodoListEntities();
            using (db)
            {
                var category = db.Todos.FirstOrDefault(c => c.Categories.name == categoryName);
                var catId = 0;

                if (category == null)
                {
                    db.Categories.Add(new Categories()
                    {
                        name = categoryName
                    });

                    catId = db.Categories.Count();
                }
                else
                {
                    catId = category.id;
                }

                db.Todos.Add(new Models.Todos()
                {
                    title = title,
                    body = body,
                    catId = catId,
                    lastChange = DateTime.Now
                });

                db.SaveChanges();
            }
        }

        protected void InsertCategory(object sender, EventArgs e)
        {
            Control control = CategoriesGridView.FooterRow;

            if (control == null)
            {
                control = CategoriesGridView.Controls[0].Controls[0];
            }

            var name = (control.FindControl("CategoryName") as TextBox).Text;

            TodoListEntities db = new TodoListEntities();
            using (db)
            {
                var category = db.Categories.FirstOrDefault(c => c.name == name);

                if (category == null)
                {
                    db.Categories.Add(new Categories()
                    {
                        name = name
                    });

                    db.SaveChanges();
                }
            }
        }
    }
}