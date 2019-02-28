using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AcmeInsurance.Data_Access_Layer
{
    class ConnectionManager
    {
        /* Establishing a connection between the application and database by
           instantiating a SqlConnection object */
        public static SqlConnection DatabaseConnection()
        {
            /* Pass location, name of database and security credentials to
            the SqlConnection object */
            string connection = "Data Source=LAPTOP-LD4RR0CA\\SQLEXPRESS;" +
                "Initial Catalog=Acme;User ID=sa;Password=sqlexpress";
            SqlConnection conn = new SqlConnection(connection);
            return conn;
        }
    }
}
