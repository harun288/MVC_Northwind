using MVC_Northwind2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind2.Controllers
{
    public class OrderController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }
        public ActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveOrder(int orderId)
        {
            var order = db.Orders.Find(orderId);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateOrder(int orderId)
        {
            var order = db.Orders.Find(orderId);
            return View(order);
        }

        [HttpPost]
        public ActionResult UpdateOrder(Order order)
        {
            var updated = db.Orders.Find(order.OrderID);
            updated.ShipName= order.ShipName;
            updated.ShipAddress = order.ShipAddress;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
    
