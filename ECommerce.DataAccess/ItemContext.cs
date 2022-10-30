using ECommerce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess
{
    public class ItemContext
    {
        DbContext db = new DbContext();

        public List<Item> GetItems()
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                List<Item> items = new List<Item>();
                SqlCommand cmd = new SqlCommand("spGetItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Item item = new Item();
                    item.Id = (Convert.ToInt32(dr[0].ToString()));
                    item.Name = dr[1].ToString();
                    item.Price = (Convert.ToDecimal(dr[2].ToString()));
                    item.Stock = (Convert.ToInt32(dr[3].ToString()));
                    item.CategoryId = (Convert.ToInt32(dr[4].ToString()));
                    items.Add(item);
                }
                conn.Close();
                return items;
            }
            catch
            {
                throw;
            }
            }

        public List<Item> GetItemsByCategory(string ctr)
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                List<Item> items = new List<Item>();
                SqlCommand cmd = new SqlCommand("spGetItemByCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", ctr);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Item item = new Item();
                    item.Id = (Convert.ToInt32(dr[0].ToString()));
                    item.Name = dr[1].ToString();
                    item.Price = (Convert.ToDecimal(dr[2].ToString()));
                    item.Stock = (Convert.ToInt32(dr[3].ToString()));
                    item.CategoryId = (Convert.ToInt32(dr[4].ToString()));
                    items.Add(item);
                }
                conn.Close();
                return items;
            }
            catch
            {
                throw;
            }
            }
        public int AddItems(Item item)
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAddItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@stock", item.Stock);
                cmd.Parameters.AddWithValue("cid", item.CategoryId);

                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch
            {
                throw;
            }
            }
        public int UpdateItem(Item item)
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("spUpdateItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@stock", item.Stock);
                cmd.Parameters.AddWithValue("cid", item.CategoryId);

                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch
            {
                throw;
            }
            }
        public int DeleteItem(int id)
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("spDeleteItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch
            {
                throw;
            }
            }
    }
}
