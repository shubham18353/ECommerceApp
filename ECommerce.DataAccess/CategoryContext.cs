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
    public class CategoryContext
    {
        DbContext db = new DbContext();

        public List<Category> GetCategories()
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                List<Category> categoryList = new List<Category>();
                SqlCommand cmd = new SqlCommand("spGetCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Category category = new Category();
                    category.Id = (Convert.ToInt32(dr[0].ToString()));
                    category.Name = dr[1].ToString();

                    categoryList.Add(category);
                }
                conn.Close();
                return categoryList;
            }
            catch
            {
                throw;
            }
        }

        public int AddCategory(Category category)
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();

                SqlCommand cmd = new SqlCommand("spAddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", category.Name);


                int i = cmd.ExecuteNonQuery();

                conn.Close();
                return i;
            }
            catch
            {
                throw;
            }
            }

        public int UpdateCategory(Category category)
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("spUpdateCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", category.Id);
                cmd.Parameters.AddWithValue("@name", category.Name);


                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteCategory(int id)
        {
            try
            {
                SqlConnection conn = db.Connection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("spDeleteCategory", conn);
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
