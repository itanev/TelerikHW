using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarySystem.Models;
using System.Text;
using Error_Handler_Control;
using System.Data.Entity.Validation;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities db = new LibrarySystemEntities();
                using (db)
                {
                    var cats = db.Categories.ToList();

                    var html = new StringBuilder();
                    html.Append("<div class='span11'>");
                    foreach (var cat in cats)
                    {
                        html.Append("<h2>");
                        html.Append(Server.HtmlDecode(cat.name));
                        html.Append("</h2>");

                        html.Append("<ul>");
                        if (cat.Books.Count > 0)
                        {
                            foreach (var book in cat.Books)
                            {
                                html.Append("<li>");
                                html.Append("<a href='BookDetails.aspx?id=" + Server.HtmlDecode(book.id.ToString()) + "'>");
                                html.Append(Server.HtmlDecode(book.title) + " by " + Server.HtmlDecode(book.author));
                                html.Append("</a>");
                                html.Append("</li>");
                            }
                        }
                        else
                        {
                            html.Append("<p class='no-books'>No books in this category.</p>");
                        }

                        html.Append("</ul>");
                    }
                    html.Append("</div>");

                    this.content.InnerHtml = html.ToString();
                }
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                ErrorSuccessNotifier.AddErrorMessage(exceptionMessage + " " + ex.EntityValidationErrors);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Search.aspx?q=" + this.searchTB.Text);
        }
    }
}