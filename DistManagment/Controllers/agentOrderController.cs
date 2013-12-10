using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistManagment.Controllers
{
    public class agentOrderController : Controller
    {
        private DistManEntities db = new DistManEntities();

        //
        // GET: /agentOrder/

        public ActionResult Index()
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            var order_agent = db.order_agent.Include(o => o.order).Include(o => o.user);
            return View(order_agent.ToList());
        }

        //
        // GET: /agentOrder/Details/5

        public ActionResult Details(int id = 0)
        {
            order_agent order_agent = db.order_agent.Find(id);
            if (order_agent == null)
            {
                return HttpNotFound();
            }
            return View(order_agent);
        }

        //
        // GET: /agentOrder/Create

        public ActionResult Create()
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            ViewBag.order_id = new SelectList(db.order, "id", "order_name");
            ViewBag.user_id = new SelectList(db.users, "id", "username");
            return View();
        }

        //
        // POST: /agentOrder/Create

        [HttpPost]
        public ActionResult Create(order_agent order_agent)
        {
            if (ModelState.IsValid)
            {
                db.order_agent.Add(order_agent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.order_id = new SelectList(db.order, "id", "order_name", order_agent.order_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", order_agent.user_id);
            return View(order_agent);
        }

        //
        // GET: /agentOrder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            order_agent order_agent = db.order_agent.Find(id);
            if (order_agent == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_id = new SelectList(db.order, "id", "order_name", order_agent.order_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", order_agent.user_id);
            return View(order_agent);
        }

        //
        // POST: /agentOrder/Edit/5

        [HttpPost]
        public ActionResult Edit(order_agent order_agent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_agent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.order_id = new SelectList(db.order, "id", "order_name", order_agent.order_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", order_agent.user_id);
            return View(order_agent);
        }

        //
        // GET: /agentOrder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            order_agent order_agent = db.order_agent.Find(id);
            if (order_agent == null)
            {
                return HttpNotFound();
            }
            return View(order_agent);
        }

        //
        // POST: /agentOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            order_agent order_agent = db.order_agent.Find(id);
            db.order_agent.Remove(order_agent);
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