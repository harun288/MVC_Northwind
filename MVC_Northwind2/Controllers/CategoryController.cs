using MVC_Northwind2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind2.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var updated = db.Categories.Find(category.CategoryID);
            updated.CategoryName = category.CategoryName;
            updated.Description = category.Description;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
    
