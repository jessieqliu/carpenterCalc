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

                c.Response.Write(s);
                c.Response.End();
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
