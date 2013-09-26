using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarySystem.Models;
using Error_Handler_Control;
using System.Data.Entity.Validation;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                var currBookId = Convert.ToInt32(Request.QueryString["id"]);
                LibrarySystemEntities db = new LibrarySystemEntities();

                using (db)
                {
                    this.bookDetails.DataSource = db.Books.Where(b => b.id == currBookId).ToList();
                    this.bookDetails.DataBind();
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
    }
}