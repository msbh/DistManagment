using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistManagment.Models;

namespace DistManagment.Controllers
{
    public class serviceController : Controller
    {
        //
        // GET: /service/

        private ServiceLogic lg = new ServiceLogic();
        //iniclize dictionary varible and data table
        private DataTable dt = new DataTable();

        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);

            IDictionary<string, Object> prem = new Dictionary<string, Object>();
            prem = ctx.ActionParameters;
            foreach (KeyValuePair<string, object> pd in prem)
            {
                string st = pd.Key;
                object ob = pd.Value;
            }
        }

        private ServiceData data = new ServiceData();

      

        public ActionResult Index()
        {
            string jsonString;

            jsonString = lg.FalseJson();
            return Content("Some Fishy found", "application/json");
        }

        public ActionResult AttackData(string st)
        {
            return Content(st, "application/json");
        }

        public ActionResult UserLogin(string username, string password)
        {
           
            dt = data.UserLogin(username, password);
            //convert object into JSON string
            string jsonString = lg.DataToJson(dt);
            //Set content type to json
            return Content(jsonString, "application/json");
        }

        public ActionResult orders(string id)
        {
            try
            {
                dt = data.orders(Convert.ToInt32(id));
            }
            catch (Exception y) { }
            //convert object into JSON string
            string jsonString = lg.DataToJson(dt);
            return Content(jsonString, "application/json");
        }
        public ActionResult ordersAccept(string id)
        {
            try
            {
                dt = data.ordersAccept(Convert.ToInt32(id));
            }
            catch (Exception y) { }
            //convert object into JSON string
            string jsonString = lg.DataToJson(dt);
            return Content(jsonString, "application/json");
        }


    }
}
