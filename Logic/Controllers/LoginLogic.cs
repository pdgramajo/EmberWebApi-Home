using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Logic.DBConnection;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace Logic.Controllers
{
    public class LoginLogic
    {
        public static User Login(string userName, string password)
        {

            using (var db = new EmberContext())
            {
                User drink = db.Database.SqlQuery<User>("GetUserByCredentials @Email,@Password", new SqlParameter("Email", userName), new SqlParameter("Password", password)).FirstOrDefault();

                return drink;

            }

        }
    }
}
