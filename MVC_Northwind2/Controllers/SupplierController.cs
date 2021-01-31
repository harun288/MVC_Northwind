using MVC_Northwind2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind2.Controllers
{
    public class SupplierController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }
        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveSupplier(int supplierId)
        {
            var supplier = db.Suppliers.Find(supplierId);
            if (supplier != null)
            {
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateSupplier(int supplierId)
        {
            var supplier = db.Suppliers.Find(supplierId);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            var updated = db.Suppliers.Find(supplier.SupplierID);
            updated.SupplierID = supplier.SupplierID;
            updated.CompanyName = supplier.CompanyName;
            updated.City = supplier.City;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
    
