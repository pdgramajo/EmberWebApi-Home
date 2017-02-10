using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic.Models
{
    public class Post 
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public List<int> comments { get; set; }
    }

    public class PostDTO
    {
        public Post post { get; set; }
        public int id { get; set; }
    }

    public class Comment 
    {
        public int id { get; set; }

        public int postId { get; set; }

        public string text { get; set; }

        public DateTime date { get; set; }

       // public Post post { get; set; }

    }

   public  class CommentDTO
    {
        public Comment comment { get; set; }
    }

    public class Category
    {
        public int id { get; set; }

        public string  title { get; set; }

        public string imageUrl { get; set; }

        public string imageId { get; set; }


    }

    public class CategoryDTO
    {
        public Category category { get; set; }
    }


    public class Drink
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string imageUrl { get; set; }

        public string imageId { get; set; }

        public int categoryId { get; set; }

    }

    public class DrinkDTO
    {
        public Drink drink { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


}
