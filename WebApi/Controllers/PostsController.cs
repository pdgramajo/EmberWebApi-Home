using Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class PostsController : ApiController
    {
        // GET: api/Posts
        public dynamic Get()
        {
            return PostsLogic.GetAllPosts();
        }

        // GET: api/Posts/5
        public dynamic Get(int id)
        {
            return PostsLogic.GetPostsById(id);
        }

        // POST: api/Posts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Posts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Posts/5
        public void Delete(int id)
        {
        }
    }
}
