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
    public class PostsLogic
    {

        /*
                context.Database.SqlQuery<myEntityType>(
                   "mySpName @param1, @param2, @param3",
                   new SqlParameter("param1", param1),
                   new SqlParameter("param2", param2),
                   new SqlParameter("param3", param3)
               );
         
         * 
         */


        public static dynamic GetAllPosts()
        {

            using (var db = new EmberContext())
            {
                var comments = db.Database.SqlQuery<Post>("GetAllPosts").ToList();

                return new { posts = comments };
            }
        }


        public static dynamic GetPostsById(int id)
        {

            using (var db = new EmberContext())
            {
                var post = db.Database.SqlQuery<Post>("GetPostsById @id",new SqlParameter("id", id)).FirstOrDefault();

                var comments = db.Database.SqlQuery<Comment>("getCommentsByPostId @postid",new SqlParameter("postid", id)).ToList();                    

                return new { post = post , comments=comments};
                
            }
        }



        //using (var db = new EmberContext())
        //{
        //    //var widgets = db.Database.SqlQuery<Widget>("usp_SmartInsight_Widget_GetAll").ToList();

        //   // return new { people = widgets };                
        //}
    }
}
