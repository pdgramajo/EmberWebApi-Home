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

            Comment com1 = new Comment() { id = 1, text = "comentari numero 1", date = new DateTime(), postId = 1 };
            Comment com2 = new Comment() { id = 2, text = "comentari numero 2", date = new DateTime(), postId = 3 };
            Comment com3 = new Comment() { id = 3, text = "comentari numero 3", date = new DateTime(), postId = 4 };
            Comment com4 = new Comment() { id = 4, text = "comentari numero 4", date = new DateTime(), postId = 2 };
            Comment com5 = new Comment() { id = 5, text = "comentari numero 5", date = new DateTime(), postId = 1 };
            Comment com6 = new Comment() { id = 6, text = "comentari numero 6", date = new DateTime(), postId = 2 };
            Comment com7 = new Comment() { id = 7, text = "comentari numero 7", date = new DateTime(), postId = 3 };
            Comment com8 = new Comment() { id = 8, text = "comentari numero 8", date = new DateTime(), postId = 4 };
            Comment com9 = new Comment() { id = 9, text = "comentari numero 9", date = new DateTime(), postId = 1 };
            Comment com10 = new Comment() { id = 10, text = "comentari numero 10", date = new DateTime(), postId = 4 };
            List<Comment> lista = new List<Comment>();
            lista.Add(com1);
            lista.Add(com2);
            lista.Add(com3);
            lista.Add(com4);
            lista.Add(com5);
            lista.Add(com6);
            lista.Add(com7);
            lista.Add(com8);
            lista.Add(com9);
            lista.Add(com10);

            using (var db = new EmberContext())
            {

                return db.Database.SqlQuery<Comment>("getallcomments").ToList();
            }


          //  return lista;

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
                   // return new { comment = result };
                }
            }
            catch (Exception e)
            {
                throw;
                //return new { comment = e };
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

            //return new { comment = new Comment() { id = 123, date = new DateTime(), postId = comment.postId, text = comment.text } };

        }

        public static dynamic GetAllComments()
        {

            return new { comments = getDataList() };
            //using (var db = new EmberContext())
            //{
            //    var comments = db.Database.SqlQuery<Comment>("getallcomments").ToList();

            //    return new { comments = comments };                
            //}


            //return new { Comments = "lista de comments" };
        }

        //using (var db = new EmberContext())
        //{
        //    //var widgets = db.Database.SqlQuery<Widget>("usp_SmartInsight_Widget_GetAll").ToList();

        //   // return new { people = widgets };                
        //}


        public static dynamic GetCommentById(int id)
        {

            //using (var db = new EmberContext())
            //{
            //    var post = db.Database.SqlQuery<Post>("GetPostsById @id",new SqlParameter("id", id)).FirstOrDefault();

            //    var comments = db.Database.SqlQuery<Comment>("getCommentsByPostId @postid",new SqlParameter("postid", id)).ToList();                    

            //    return new { post = post , comments=comments};

            //}

            return new { comment = getDataList().Find(x => x.id == id) };

        }

        public static dynamic GetCommentByPostId(int id)
        {

            //using (var db = new EmberContext())
            //{
            //    var post = db.Database.SqlQuery<Post>("GetPostsById @id",new SqlParameter("id", id)).FirstOrDefault();

            //    var comments = db.Database.SqlQuery<Comment>("getCommentsByPostId @postid",new SqlParameter("postid", id)).ToList();                    

            //    return new { post = post , comments=comments};

            //}

            List<int> data = getDataList().FindAll(x => x.postId == id ).Select(y => y.id).ToList();

            return  data ;

        }


    }
}
