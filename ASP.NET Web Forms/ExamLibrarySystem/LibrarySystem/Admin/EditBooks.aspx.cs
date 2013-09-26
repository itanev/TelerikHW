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
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        public IQueryable<BookModel> booksGridView_GetData()
        {
            try
            {
                LibrarySystemEntities db = new LibrarySystemEntities();
                var books = (from b in db.Books.ToList()
                             select new BookModel()
                             {
                                 Id = b.id,
                                 Title = b.title.Substring(0, Math.Min(b.title.Length, 20)) + "...",
                                 Author = b.author,
                                 Description = b.description,
                                 Isbn = b.isbn,
                                 WebSite = b.webSite,
                                 Category = db.Categories.Find(b.categoryId).name
                             });
                return books.AsQueryable<BookModel>();
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
                var currBook = db.Books.FirstOrDefault(b => b.id == id);

                currBook.title = bookTitle.Text;
                currBook.author = bookAuthor.Text;
                currBook.isbn = bookIsbn.Text;
                currBook.webSite = bookWebSite.Text;
                currBook.description = bookDescr.Text;
                currBook.categoryId = db.Categories.First(b => b.name == bookCats.SelectedItem.Value).id;
                db.SaveChanges();
                Response.Redirect("~/Admin/EditBooks.aspx");
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
            this.bookEdit.Visible = false;
            Response.Redirect("~/Admin/EditBooks.aspx");
        }

        protected void Delete_Command_Confirm(object sender, CommandEventArgs e)
        {
            try
            {
                bookEdit.Visible = false;
                bookNew.Visible = false;
                deleteConfirmationBox.Visible = true;

                var id = Convert.ToInt32(e.CommandArgument);

                LibrarySystemEntities db = new LibrarySystemEntities();
                var currCat = db.Books.FirstOrDefault(c => c.id == id);

                categoryName.Text = currCat.title;
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
                var currBook = db.Books.FirstOrDefault(c => c.id == id);

                if (currBook != null)
                {
                    db.Books.Remove(currBook);
                    db.SaveChanges();
                    Response.Redirect("~/Admin/EditBooks.aspx");
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
                var currBook = db.Books.FirstOrDefault(c => c.id == id);

                if (currBook != null)
                {
                    this.bookEdit.Visible = true;
                    this.bookNew.Visible = false;

                    this.bookTitle.Text = currBook.title;
                    this.bookAuthor.Text = currBook.author;
                    this.bookDescr.Text = currBook.description;
                    this.bookIsbn.Text = currBook.isbn;
                    this.bookWebSite.Text = currBook.webSite;
                    this.bookCats.DataSource = db.Categories.ToList();
                    this.bookCats.DataBind();
                    this.updateBook.CommandArgument = currBook.id.ToString();
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

        protected void createNewBook_Click(object sender, EventArgs e)
        {
            try
            {
                this.bookEdit.Visible = false;
                this.bookNew.Visible = true;
                LibrarySystemEntities db = new LibrarySystemEntities();
                bookNewCat.DataSource = db.Categories.ToList();
                bookNewCat.DataBind();
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

        protected void CreateBook_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarySystemEntities db = new LibrarySystemEntities();
                bookNewCat.DataSource = db.Categories.ToList();
                bookNewCat.DataBind();

                db.Books.Add(new Books()
                {
                    title = bookNewTitle.Text,
                    author = bookNewAuthor.Text,
                    isbn = bookNewIsbn.Text,
                    description = bookNewDescr.Text,
                    webSite = bookNewWebSite.Text,
                    categoryId = db.Categories.First(b => b.name == bookNewCat.SelectedItem.Value).id
                });

                db.SaveChanges();
                Response.Redirect("~/Admin/EditBooks.aspx");
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