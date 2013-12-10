using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DistManagment.Models;
using WebMatrix.WebData;

namespace DistManagment.Controllers
{
    public class HomeController : Controller
    {
       private DistManEntities db = new DistManEntities();
        public ActionResult Index()
        {
            try { if (Session["userid"].ToString() == "") { return RedirectToAction("LoginUser", "Home"); } }catch (Exception et) {return RedirectToAction("LoginUser", "Home"); }
            ViewBag.Message = "This is Dashboard.";

            ViewBag.productcount = db.products.Count();
            ViewBag.ordercount = db.order.Count();
            ViewBag.agentsorder = db.order_agent.Count();
            ViewBag.deliveredorder = db.order.Where(x=>x.status==true).Count();

            return View();
        }

        public ActionResult LogoffUser()
        {
            Session["userid"] = "";
           return RedirectToAction("LoginUser");
            
        }
        public ActionResult LoginUser()
        {
            try { if (Session["userid"].ToString() != "") { return RedirectToAction("Index"); } }
            catch (Exception et) {  }
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(LoginModel model)
        {

            if (model.UserName==""||model.Password=="")
            {
                return View();
            }

            // If we got this far, something failed, redisplay form
          
            try
            {
               
                user usr = db.users.Where(x => x.username == model.UserName && x.password == model.Password).FirstOrDefault();
                if (usr != null) {
                    Session["userid"] = usr.id; 
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect."); 
            }
            catch (Exception er)
            {
                return View();
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
