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
         
       //using (var db = new EmberContext())
        //{
        //    //var data = db.Database.SqlQuery<MiClass>("storedProcedure").ToList();

        //   // return new { people = data };                
        //}

         * 
         */
        private static List<Post> getDataList() {

            Post post1 = new Post() { id = 1, title = "Chemical Engineer", description = "1 porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.\n\nFusce consequat. Nulla nisl. Nunc nisl.", comments = CommentLogic.GetCommentByPostId(1) };
            Post post2 = new Post() { id = 2, title = "Chemical Enginee2", description = "2 porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.\n\nFusce consequat. Nulla nisl. Nunc nisl.", comments = CommentLogic.GetCommentByPostId(2)};
            Post post3 = new Post() { id = 3, title = "Chemical Enginee3", description = "3 porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.\n\nFusce consequat. Nulla nisl. Nunc nisl.", comments = CommentLogic.GetCommentByPostId(3)};
            Post post4 = new Post() { id = 4, title = "Chemical Enginee4", description = "4 porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.\n\nFusce consequat. Nulla nisl. Nunc nisl.", comments = CommentLogic.GetCommentByPostId(4)};

            List<Post> list = new List<Post>();
            list.Add(post1);
            list.Add(post2);
            list.Add(post3);
            list.Add(post4);

            return list;
        }

        public static dynamic GetAllPosts()
        {

            using (var db = new EmberContext())
            {
                var posts = db.Database.SqlQuery<Post>("GetAllPosts").ToList().Select(y => new Post() { 
                                                                                                         id = y.id,
                                                                                                         description = y.description,
                                                                                                         title = y.title,
                                                                                                         comments = CommentLogic.GetCommentByPostId(y.id)                 
                });

                return new { posts = posts };
            }

          //  return new { posts = getDataList() };
        }


        public static dynamic GetPostsById(int id)
        {

            using (var db = new EmberContext())
            {
                var post = db.Database.SqlQuery<Post>("GetPostsById @id", new SqlParameter("id", id)).Select(y => new Post() {
                
                    id = y.id,
                    description = y.description,
                    title = y.description,
                    comments = CommentLogic.GetCommentByPostId(y.id)                 

                }).FirstOrDefault();

                //var comments = db.Database.SqlQuery<Comment>("getCommentsByPostId @postid", new SqlParameter("postid", id)).ToList();

                return new { post = post};

            }

         //   return  new { post = getDataList().Find(x => x.id == id) };

        }

    }
}
