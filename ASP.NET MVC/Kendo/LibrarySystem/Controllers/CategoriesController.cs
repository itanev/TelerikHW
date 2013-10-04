using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LibrarySystem.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriesRead([DataSourceRequest]DataSourceRequest request)
        {
            var result = GetCategoriesAsViewModel(db.Categories);

            return Json(new[] { result.ToDataSourceResult(request) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CategoriesCreate([DataSourceRequest]DataSourceRequest request, CategoryViewModel Category)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = Category.Name,
                };

                db.Categories.Add(entity);
                db.SaveChanges();
                Category.Name = entity.Name;
            }

            return Json(new[] { Category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CategoriesUpdate([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var currCategory = db.Categories.Find(category.Id);
                currCategory.Name = category.Name;
                db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CategoriesDestroy([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var currCategory = db.Categories.Find(category.Id);
                db.Categories.Remove(currCategory);
                db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        private IQueryable<CategoryViewModel> GetCategoriesAsViewModel(DbSet<Category> AllCategories)
        {
            var result = from cat in AllCategories
                         select new CategoryViewModel
                         {
                             Id = cat.Id,
                             Name = cat.Name
                         };
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}