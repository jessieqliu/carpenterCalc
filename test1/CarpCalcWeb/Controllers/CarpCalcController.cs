using carpenterCalcCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace CarpCalcWeb.Controllers
{
    public class CarpCalcController : ApiController
    {
        // GET: api/CarpCalc
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CarpCalc/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CarpCalc
        public void Post([FromBody]string value)
        {
            HttpContext c = HttpContext.Current;

            c.Response.ContentType = "application/json";
            c.Response.ContentEncoding = Encoding.UTF8;

            System.IO.Stream body = c.Request.InputStream;
            System.Text.Encoding encoding = c.Request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            if (c.Request.ContentType != "application/json")
            {
                c.Response.Write("incorrect content type");
                c.Response.End();
            }
            else
            {
                string s = reader.ReadToEnd();

                try
                {
                    Request r1 = JsonConvert.DeserializeObject<Request>(s);
                    CCUnit result = null;
                    if (r1.calcOperator == '+')
                    {
                        if (r1.CCUnits.Length == 2)
                            result = r1.CCUnits[0] + r1.CCUnits[1];
                    }

                    if (result != null)
                    {
                        s = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
                    }
                    else
                        s = "ERROR: Invalid Input Format.";

                    c.Response.Write(s);
                    c.Response.End();
                } catch(Exception e)
                {

                }
            }
        }

        // PUT: api/CarpCalc/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CarpCalc/5
        public void Delete(int id)
        {
        }
    }
}
