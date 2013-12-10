using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DistManagment.Models
{
    public class ServiceData
    {
        private DistManEntities db = new DistManEntities();
        public DataTable UserLogin(string UserName, string Password)
        {
            DataTable dt = new DataTable();

            if (UserName == "" || Password == "")
            {
                return (dt);
            }

            //Using mobily serives fatch data
            try
            {
                var gradeData = db.users.Where(x => x.username == UserName && x.password == Password).ToList();
                foreach (var item in gradeData)
                {
                    dt.Rows.Add(item.id, item.username, item.isAdmin);
                }
            }
            catch (Exception ee) { }

            return (dt);
        }
        public DataTable orders(int id)
        {
            DataTable dt = new DataTable();

            if (id == null)
            {
                return (dt);
            }

            //Using mobily serives fatch data
            try
            {
                var query = from c in db.order
                            join o in db.order_agent on c.id equals o.id
                            where o.user_id == id 
                            && c.status==false
                            select new { c };

                foreach (var item in query)
                {
                    dt.Rows.Add(item.c.deliver_date, item.c.deliver_to, item.c.order_name, item.c.qty, item.c.status);
                }
            }
            catch (Exception ee) { }

            return (dt);
        }
        public DataTable ordersAccept(int id)
        {
            DataTable dt = new DataTable();

            if (id == null)
            {
                return (dt);
            }

            //Using mobily serives fatch data
            try
            {
                order or = db.order.Find(id);
                or.status = true;
                db.Entry(or).State = EntityState.Modified;
                db.SaveChanges();

                var query = from c in db.order
                            join o in db.order_agent on c.id equals o.id
                            where o.user_id == id
                            && c.status == false
                            select new { c };

                foreach (var item in query)
                {
                    dt.Rows.Add(item.c.deliver_date, item.c.deliver_to, item.c.order_name, item.c.qty, item.c.status);
                }
            }
            catch (Exception ee) { }

            return (dt);
        }

    }
}