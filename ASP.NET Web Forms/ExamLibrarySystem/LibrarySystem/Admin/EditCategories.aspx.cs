using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarySystem.Models;
using Error_Handler_Control;
using System.Data.Entity.Validation;

namespace LibrarySystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Categories> catsGridView_GetData()
        {
            try
            {
                LibrarySystemEntities db = new LibrarySystemEntities();
                return db.Categories.OrderBy(q => q.id);
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

        protected void SaveBtn_Click(object sender, CommandEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(e.CommandArgument);

                LibrarySystemEntities db = new LibrarySystemEntities();
                var currCat = db.Categories.FirstOrDefault(c => c.id == id);

                currCat.name = catName.Text;
                db.SaveChanges();
                Response.Redirect("~/Admin/EditCategories.aspx");
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

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            this.catEdit.Visible = false;
            Response.Redirect("~/Admin/EditCategories.aspx");
        }

        protected void Delete_Command_Confurm(object sender, CommandEventArgs e)
        {
            try
            {
                catEdit.Visible = false;
                catNew.Visible = false;
                deleteConfirmationBox.Visible = true;

                var id = Convert.ToInt32(e.CommandArgument);

                LibrarySystemEntities db = new LibrarySystemEntities();
                var currCat = db.Categories.FirstOrDefault(c => c.id == id);

                categoryName.Text = currCat.name;
                deleteCatBtn.CommandArgument = currCat.id.ToString();
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

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(e.CommandArgument);

                LibrarySystemEntities db = new LibrarySystemEntities();
                var currCat = db.Categories.FirstOrDefault(c => c.id == id);

                if (currCat != null)
                {
                    foreach (var book in currCat.Books.ToList())
                    {
                        db.Books.Remove(book);
                    }

                    db.SaveChanges();
                    db.Categories.Remove(currCat);
                    db.SaveChanges();
                    Response.Redirect("~/Admin/EditCategories.aspx");
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

        protected void Edit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(e.CommandArgument);

                LibrarySystemEntities db = new LibrarySystemEntities();
                var currCat = db.Categories.FirstOrDefault(c => c.id == id);

                if (currCat != null)
                {
                    this.catEdit.Visible = true;
                    this.catNew.Visible = false;
                    this.catName.Text = currCat.name;
                    this.updateCat.CommandArgument = currCat.id.ToString();
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

        protected void createNewCat_Click(object sender, EventArgs e)
        {
            this.catEdit.Visible = false;
            this.catNew.Visible = true;
        }

        protected void CreateCat_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities db = new LibrarySystemEntities();
                db.Categories.Add(new Categories()
                {
                    name = newCatName.Text
                });

                db.SaveChanges();
                Response.Redirect("~/Admin/EditCategories.aspx");
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