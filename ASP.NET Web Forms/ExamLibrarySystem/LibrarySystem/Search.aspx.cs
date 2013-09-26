using Error_Handler_Control;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var q = Request.QueryString["q"];
            queryText.InnerText = "Search Results for Query `" + q + "`.";
        }

        public IQueryable<BookModel> booksListView_GetData()
        {
            try
            {
                var q = Request.QueryString["q"].ToLower();
                LibrarySystemEntities db = new LibrarySystemEntities();

                if (q.Length >= 20000)
                {
                    throw new ArgumentOutOfRangeException("The search phrase is too long. It must be less than 20000 characters.");
                }

                if (q == string.Empty)
                {
                    var books = (from b in db.Books.ToList()
                                 select new BookModel()
                                 {
                                     Id = b.id,
                                     Title = b.title,
                                     Author = b.author,
                                     Description = b.description,
                                     Isbn = b.isbn,
                                     WebSite = b.webSite,
                                     Category = db.Categories.Find(b.categoryId).name
                                 });
                    return books.OrderBy(b => b.Title).ThenBy(b => b.Author).AsQueryable<BookModel>();
                }
                else
                {
                    var books = (from b in db.Books.ToList()
                                 where (b.author.ToLower().Contains(q) || b.title.ToLower().Contains(q))
                                 select new BookModel()
                                 {
                                     Id = b.id,
                                     Title = b.title,
                                     Author = b.author,
                                     Description = b.description,
                                     Isbn = b.isbn,
                                     WebSite = b.webSite,
                                     Category = db.Categories.Find(b.categoryId).name
                                 });
                    return books.OrderBy(b => b.Title).ThenBy(b => b.Author).AsQueryable<BookModel>();
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

            return null;
        }
    }
}