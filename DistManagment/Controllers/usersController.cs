using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistManagment.Controllers
{
    public class usersController : Controller
    {
        private DistManEntities db = new DistManEntities();

        //
        // GET: /users/

        public ActionResult Index()
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            return View(db.users.ToList());
        }

        //
        // GET: /users/Details/5

        public ActionResult Details(int id = 0)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            user users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // GET: /users/Create

        public ActionResult Create()
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            return View();
        }

        //
        // POST: /users/Create

        [HttpPost]
        public ActionResult Create(user users)
        {
            DateTime dte = DateTime.Now;
            if (ModelState.IsValid)
            {
                users.created_date = dte.ToString();
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(users);
        }

        //
        // GET: /users/Edit/5

        public ActionResult Edit(int id = 0)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            user users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
           
            return View(users);
        }

        //
        // POST: /users/Edit/5

        [HttpPost]
        public ActionResult Edit(user users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        //
        // GET: /users/Delete/5

        public ActionResult Delete(int id = 0)
        {
             try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            user users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //
        // POST: /users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user users = db.users.Find(id);
            db.users.Remove(users);
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