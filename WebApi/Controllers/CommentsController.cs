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
    public class CommentsController : ApiController 
    {
        // GET: api/Comments
        public dynamic Get()
        {
            return CommentLogic.GetAllComments();
        }

        // GET: api/Comments/5
        public dynamic Get(int id)
        {
            return CommentLogic.GetCommentById(id);
        }

        // POST: api/Comments
        public dynamic Post([FromBody] CommentDTO value)
        {
            return CommentLogic.addComment(value.comment);
        }

        // PUT: api/Comments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comments/5
        public void Delete(int id)
        {
            CommentLogic.DeleteComment(id);
        }
    }
}
