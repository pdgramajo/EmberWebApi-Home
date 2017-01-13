using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class FilesController : ApiController
    {
        // GET: api/Files
        public dynamic Get()
        {
            DateTime localDate = DateTime.Now;
            return new { timestamp = localDate };
        }

        // GET: api/Files/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Files
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Files/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Files/5
        public void Delete(int id)
        {
        }
    }
}
