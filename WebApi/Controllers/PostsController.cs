using Logic.Controllers;
using Logic.Models;
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
        public dynamic Post([FromBody]PostDTO value)
        {

            return PostsLogic.AddNewPost(value.post);
        }

        // PUT: api/Posts/5
        public void Put(int id, [FromBody]PostDTO value)
        {
            
        }

        // DELETE: api/Posts/5
        public void Delete(int id)
        {
            PostsLogic.DeletePost(id);
        }
    }
}
