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
    public class DrinksLogic
    {


        public static dynamic GetDrinksByCategoryId(int id)
        {

            using (var db = new EmberContext())
            {
                var drinks = db.Database.SqlQuery<Drink>("GetDrinksByCategoryId @categoryId", new SqlParameter("categoryId", id)).ToList();

                return new { drinks = drinks };

            }
        }

        public static dynamic GetAllDrinks()
        {
            using (var db = new EmberContext())
            {
                var drinks = db.Database.SqlQuery<Drink>("GetAllDrinks").ToList();

                return new { drinks = drinks };

            }
        }

        public static dynamic GetDrinksById(int id)
        {
            using (var db = new EmberContext())
            {
                var drink = db.Database.SqlQuery<Drink>("GetDrinksById @id", new SqlParameter("id", id)).FirstOrDefault();

                return new { drink = drink };

            }
        }

        public static dynamic GetAllDrinks(int id)
        {

            using (var db = new EmberContext())
            {
                var drinks = db.Database.SqlQuery<Drink>("GetAllDrinks").ToList();

                return new { drinks = drinks };

            }
        }

        public static dynamic GetDrinksByCategoryIdRelationships(int id)
        {

            using (var db = new EmberContext())
            {
                List<int> data = db.Database.SqlQuery<Drink>("GetDrinksByCategoryId @categoryId", new SqlParameter("categoryId", id)).Select(x=>x.id).ToList();

                return data;

            }

            //List<int> data = GetDrinksByCategoryId(id) => x.postId == id).Select(y => y.id).ToList();

            //return data;
        }


    }
}
