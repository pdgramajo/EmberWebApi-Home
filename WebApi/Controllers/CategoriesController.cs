using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic.Controllers;

namespace WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        public dynamic Get()
        {
            return CategoriesLogic.getAllCategories();
        }

        // GET: api/Categories/5
        public dynamic Get(int id)
        {
            return CategoriesLogic.getCategoryById(id);
        }

        // POST: api/Categories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
        }
    }
}
