using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistManagment.Controllers
{
    public class orderProductsController : Controller
    {
        private DistManEntities db = new DistManEntities();

        //
        // GET: /orderProducts/

        public ActionResult Index()
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            var order_product = db.order_product.Include(o => o.order).Include(o => o.product);
            return View(order_product.ToList());
        }

        //
        // GET: /orderProducts/Details/5

        public ActionResult Details(int id = 0)
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            order_product order_product = db.order_product.Find(id);
            if (order_product == null)
            {
                return HttpNotFound();
            }
            return View(order_product);
        }

        //
        // GET: /orderProducts/Create

        public ActionResult Create()
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            ViewBag.order_id = new SelectList(db.order, "id", "order_name");
            ViewBag.product_id = new SelectList(db.products, "id", "product_name");
            return View();
        }

        //
        // POST: /orderProducts/Create

        [HttpPost]
        public ActionResult Create(order_product order_product)
        {
            ViewBag.order_id = new SelectList(db.order, "id", "order_name", order_product.order_id);
            ViewBag.product_id = new SelectList(db.products, "id", "product_name", order_product.product_id);
            int tempId = order_product.product_id;
            products product = db.products.Find(tempId);
            if (order_product.qty > product.stock)
            {
                ViewBag.error = "Stock Not available";
                return View(order_product);
            }
            product.stock = product.stock - order_product.qty;

            if (ModelState.IsValid)
            {
                db.order_product.Add(order_product);
                db.SaveChanges();
                saveProduct(product);
                return RedirectToAction("Index");
            }

            
            return View(order_product);
        }

        //
        // GET: /orderProducts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            order_product order_product = db.order_product.Find(id);
            if (order_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_id = new SelectList(db.order, "id", "order_name", order_product.order_id);
            ViewBag.product_id = new SelectList(db.products, "id", "product_name", order_product.product_id);
       
            return View(order_product);
        }

        //
        // POST: /orderProducts/Edit/5

        [HttpPost]
        public ActionResult Edit(order_product order_product)
        {
            ViewBag.order_id = new SelectList(db.order, "id", "order_name", order_product.order_id);
            ViewBag.product_id = new SelectList(db.products, "id", "product_name", order_product.product_id);
            int tempId = order_product.product_id;
            products product = db.products.Find(tempId);
            if (order_product.qty > product.stock)
            {
                ViewBag.error = "Stock Not available";
                return View(order_product);
            }
            product.stock = product.stock - order_product.qty;

            if (ModelState.IsValid)
            {
                db.Entry(order_product).State = EntityState.Modified;
                db.SaveChanges();
                saveProduct(product);
                return RedirectToAction("Index");
            }
           
            return View(order_product);
        }
        public void saveProduct(products p1){
            db.Entry(p1).State = EntityState.Modified;
            db.SaveChanges();
        }
        //
        // GET: /orderProducts/Delete/5

        public ActionResult Delete(int id = 0)
        {

            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            order_product order_product = db.order_product.Find(id);
            if (order_product == null)
            {
                return HttpNotFound();
            }
            return View(order_product);
        }

        //
        // POST: /orderProducts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            order_product order_product = db.order_product.Find(id);
            db.order_product.Remove(order_product);
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