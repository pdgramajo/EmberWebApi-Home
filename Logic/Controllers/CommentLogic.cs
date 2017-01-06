using Logic.DBConnection;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
    public class CommentLogic
    {
        private static List<Comment> getDataList() {

            using (var db = new EmberContext())
            {
                return db.Database.SqlQuery<Comment>("getallcomments").ToList();
            }
        }

        public static void DeleteComment(int id)
        {
            try
            {
                using (var db = new EmberContext())
                {
                    var result = db.Database.SqlQuery<string>("DeleteCommentById @id",
                        new SqlParameter("@id", id)
                        ).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static dynamic addComment(Comment comment)
        {
            try
            {                
                using (var db = new EmberContext())
                {
                    int commentid = db.Database.SqlQuery<int>("AddComment @text, @postId,@date ",
                        new SqlParameter("@text", comment.text),
                        new SqlParameter("@postId", comment.postId),
                        new SqlParameter("@date", DateTime.Now)
                        ).FirstOrDefault();
                    return GetCommentById(commentid);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static dynamic GetAllComments()
        {
            return new { comments = getDataList() };
        }

        public static dynamic GetCommentById(int id)
        {
            return new { comment = getDataList().Find(x => x.id == id) };
        }

        public static dynamic GetCommentByPostId(int id)
        {
            List<int> data = getDataList().FindAll(x => x.postId == id ).Select(y => y.id).ToList();

            return  data ;
        }
    }
}
