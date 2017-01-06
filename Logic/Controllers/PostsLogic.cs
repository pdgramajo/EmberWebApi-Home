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
        public static void DeletePost(int id)
        {
            try
            {
                using (var db = new EmberContext())
                {
                    var result = db.Database.SqlQuery<string>("DeletePostById @id",
                        new SqlParameter("@id", id)
                        ).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static dynamic GetAllPosts()
        {

            using (var db = new EmberContext())
            {
                var posts = db.Database.SqlQuery<Post>("GetAllPosts").ToList().Select(y => new Post()
                {
                    id = y.id,
                    description = y.description,
                    title = y.title,
                    comments = CommentLogic.GetCommentByPostId(y.id)
                });

                return new { posts = posts };
            }
        }

        public static dynamic GetPostsById(int id)
        {

            using (var db = new EmberContext())
            {
                var post = db.Database.SqlQuery<Post>("GetPostsById @id", new SqlParameter("id", id)).Select(y => new Post()
                {
                    id = y.id,
                    description = y.description,
                    title = y.title,
                    comments = CommentLogic.GetCommentByPostId(y.id)                
                }).FirstOrDefault();
                
                return new { post = post };

            }
        }

        public static dynamic AddNewPost(Post post)
        {
            try
            {
                using (var db = new EmberContext())
                {
                    int postId = db.Database.SqlQuery<int>("AddNewPost @title, @description ",
                        new SqlParameter("@title", post.title),
                        new SqlParameter("@description", post.description)                        
                        ).FirstOrDefault();
                    return GetPostsById(postId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
