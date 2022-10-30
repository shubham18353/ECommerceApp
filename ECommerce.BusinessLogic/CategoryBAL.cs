using ECommerce.BusinessObjects;
using ECommerce.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLogic
{
    public class CategoryBAL
    {
        CategoryContext category = new CategoryContext();
        public List<Category> Get()
        {
            return category.GetCategories();
        }

        public int Add(Category it)
        {
            return category.AddCategory(it);
        }
        public int Update(Category it)
        {
            return category.UpdateCategory(it);
        }
        public int Delete(int id)
        {
            return category.DeleteCategory(id);
        }
    }
}
