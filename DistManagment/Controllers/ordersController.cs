using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistManagment.Controllers
{
    public class ordersController : Controller
    {
        private DistManEntities db = new DistManEntities();

        //
        // GET: /orders/

        public ActionResult Index()
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }
            catch (Exception et) { return RedirectToAction("LoginUser", "Home"); }
          
            return View(db.order.ToList());
        }

        //
        // GET: /orders/Details/5

        public ActionResult Details(int id = 0)
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }
            catch (Exception et) { return RedirectToAction("LoginUser", "Home"); }
            order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // GET: /orders/Create

        public ActionResult Create()
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            return View();
        }

        //
        // POST: /orders/Create

        [HttpPost]
        public ActionResult Create(order order)
        {
            if (ModelState.IsValid)
            {
                db.order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        //
        // GET: /orders/Edit/5

        public ActionResult Edit(int id = 0)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /orders/Edit/5

        [HttpPost]
        public ActionResult Edit(order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //
        // GET: /orders/Delete/5

        public ActionResult Delete(int id = 0)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /orders/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.order.Find(id);
            db.order.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}