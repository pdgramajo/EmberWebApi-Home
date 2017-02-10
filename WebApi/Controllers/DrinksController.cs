using Logic.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
   
    public class DrinksController : ApiController
    {
        // GET: api/Drinks
        public dynamic Get()
        {
            return DrinksLogic.GetAllDrinks();
        }

        // GET: api/Drinks/5
        public dynamic Get(int id)
        {
            return DrinksLogic.GetDrinksById(id);
        }

        // POST: api/Drinks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Drinks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Drinks/5
        public void Delete(int id)
        {
        }
    }
}
