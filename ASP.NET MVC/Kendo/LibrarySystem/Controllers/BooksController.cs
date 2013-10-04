using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace LibrarySystem.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var books = from b in db.Books
                        select new BookViewModel
                        {
                            Id = b.Id,
                            Author = b.Author,
                            CategoryName = b.Category.Name,
                            Description = b.Description,
                            Title = b.Title,
                            Isbn = b.Isbn,
                        };

            DataSourceResult result = books.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request, BookViewModel book, 
            Dictionary<string, string> Category)
        {
            if (ModelState.IsValid)
            {
                int currCategoryId = int.Parse(Category["Id"].ToString());
                var entity = new Book
                {
                    Author = book.Author,
                    Description = book.Description,
                    Category = db.Categories.Find(currCategoryId),
                    Isbn = book.Isbn,
                    Title = book.Title
                };

                db.Books.Add(entity);
                db.SaveChanges();

                book.Author = entity.Author;
                book.Title = entity.Title;
                book.Description = entity.Description;
                book.Isbn = entity.Isbn;
                book.CategoryName = entity.Category.Name;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([DataSourceRequest]DataSourceRequest request, BookViewModel book,
            Dictionary<string, string> Category)
        {
            if (ModelState.IsValid)
            {
                var selectedCategoryId = int.Parse(Category["Id"]);
                var currBook = db.Books.Find(book.Id);
                currBook.Title = book.Title;
                currBook.Author = book.Author;
                currBook.Description = book.Description;
                currBook.Isbn = book.Isbn;
                currBook.Category = db.Categories.Find(selectedCategoryId);

                db.SaveChanges();

                book.Title = currBook.Title;
                book.Description = currBook.Description;
                book.Isbn = currBook.Isbn;
                book.Author = currBook.Author;
                book.CategoryName = currBook.Category.Name;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var currBook = db.Books.Find(book.Id);
                db.Books.Remove(currBook);
                db.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
