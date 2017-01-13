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
   public class CategoriesLogic
    {

        private static List<Category> getDataList()
        {

            using (var db = new EmberContext())
            {
                return db.Database.SqlQuery<Category>("GetAllcategories").ToList();
            }
        }

        public static dynamic getCategoryById(int id)
        {
            return new { category = getDataList().Select(y=> new {
               id= y.id,
                title = y.title,
                imageId = y.imageId,
                imageUrl = y.imageUrl,
                drinks = DrinksLogic.GetDrinksByCategoryIdRelationships(y.id)
            }).ToList().Find(x => x.id == id) };
        }

        public static dynamic getAllCategories()
        {            
            return new { categories = getDataList().Select(x=> new {
                x.id,
                x.title,
                x.imageUrl,
                x.imageId,
                drinks = DrinksLogic.GetDrinksByCategoryIdRelationships(x.id)
            }).ToList(),
                
            };
        }

        public static void DeleteCategory(int id)
        {
            try
            {
                using (var db = new EmberContext())
                {
                    var result = db.Database.SqlQuery<string>("DeleteCategoryById @id",
                        new SqlParameter("@id", id)
                        ).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
