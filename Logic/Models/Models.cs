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

    public class Comment
    {
        public int id { get; set; }

        public int postId { get; set; }

        public string text { get; set; }

        public DateTime date { get; set; }

       // public Post post { get; set; }

    }
}
