using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DistManagment.Models
{
    public class ServiceLogic
    {
        public string DataToJson(DataTable dt)
        {
            try
            {
                IDictionary<string, string> stroutput = new Dictionary<string, string>();
                IDictionary<string, object> output = new Dictionary<string, object>();
                if (dt.Rows.Count > 0)
                {
                    output["data"] = dt;
                    output["status"] = "true";
                }
                else
                {
                    output["data"] = "";
                    output["status"] = "false";
                }
                //convert object into JSON string
                string jsonString = JsonConvert.SerializeObject(output);
                return (jsonString);
            }
            catch (Exception ert)
            {
                return ("");
            }
        }
        public string FalseJson()
        {
            try
            {
                IDictionary<string, string> stroutput = new Dictionary<string, string>();
                IDictionary<string, object> output = new Dictionary<string, object>();
                output["data"] = "";
                output["status"] = "false";

                //convert object into JSON string
                string jsonString = JsonConvert.SerializeObject(output);
                return (jsonString);
            }
            catch (Exception ert)
            {
                return ("");
            }
        }

    }
}