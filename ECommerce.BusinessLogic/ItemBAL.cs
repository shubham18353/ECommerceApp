using ECommerce.BusinessObjects;
using ECommerce.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLogic
{
    public class ItemBAL
    {
        ItemContext item = new ItemContext();
        public List<Item> Get()
        {
            return item.GetItems();
        }
        public List<Item> GetByCategory(string cat)
        {
            return item.GetItemsByCategory(cat);
        }
        public int Add(Item it)
        {
            return item.AddItems(it);
        }
        public int Update(Item it)
        {
            return item.UpdateItem(it);
        }
        public int Delete(int id)
        {
            return item.DeleteItem(id);
        }
    }
}
