using MVC_Northwind2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind2.Controllers
{
    public class ShipperController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Shipper
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }
        public ActionResult AddShipper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddShipper(Shipper shipper)
        {
            db.Shippers.Add(shipper);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveShipper(int shipperId)
        {
            var shipper = db.Shippers.Find(shipperId);
            if (shipper != null)
            {
                db.Shippers.Remove(shipper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateShipper(int shipperId)
        {
            var shipper = db.Shippers.Find(shipperId);
            return View(shipper);
        }

        [HttpPost]
        public ActionResult UpdateShipper(Shipper shipper)
        {
            var updated = db.Shippers.Find(shipper.ShipperID);
            updated.CompanyName = shipper.CompanyName;
            updated.Phone = shipper.Phone;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
    
