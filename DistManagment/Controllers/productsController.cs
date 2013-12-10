using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistManagment.Controllers
{
    public class productsController : Controller
    {
        private DistManEntities db = new DistManEntities();

        //
        // GET: /products/

        public ActionResult Index()
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            return View(db.products.ToList());
        }

        //
        // GET: /products/Details/5

        public ActionResult Details(int id = 0)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // GET: /products/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /products/Create

        [HttpPost]
        public ActionResult Create(products products)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        //
        // GET: /products/Edit/5

        public ActionResult Edit(int id = 0)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // POST: /products/Edit/5

        [HttpPost]
        public ActionResult Edit(products products)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        //
        // GET: /products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // POST: /products/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            products products = db.products.Find(id);
            db.products.Remove(products);
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