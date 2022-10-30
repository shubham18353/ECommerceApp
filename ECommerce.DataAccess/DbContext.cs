using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess
{
    public class DbContext
    {
        string connectionString = "Data Source=.;Initial Catalog=ECommerce;Integrated Security=True";
        public SqlConnection Connection()
        {
            SqlConnection con= new SqlConnection(connectionString);
            return con;
        }

    }
}
