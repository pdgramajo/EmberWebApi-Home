using Logic.DBConnection;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
    public class CommentLogic
    {

        public static dynamic GetAllComments()
        {


            using (var db = new EmberContext())
            {
                var comments = db.Database.SqlQuery<Comment>("getallcomments").ToList();

                return new { comments = comments };                
            }


            //return new { Comments = "lista de comments" };
        }

        //using (var db = new EmberContext())
        //{
        //    //var widgets = db.Database.SqlQuery<Widget>("usp_SmartInsight_Widget_GetAll").ToList();

        //   // return new { people = widgets };                
        //}

    }
}
