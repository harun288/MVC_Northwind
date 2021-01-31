using MVC_Northwind2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind2.Controllers
{
   
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateProduct(int productId)
        {
            var product = db.Products.Find(productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var updated = db.Products.Find(product.ProductID);
            updated.ProductName = product.ProductName;
            updated.UnitPrice = product.UnitPrice;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
    
