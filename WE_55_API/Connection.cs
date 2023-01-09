using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
namespace WE_55_API
{
    public class Connection
    {
        public static SqlConnection sqlConnection;
        public static SqlConnection GetSqlConnection()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=CL2-12\SQLEXPRESS; Initial Catalog=InstituteAttendenceSystem;User=sa;Password=UIT12345";
                sqlConnection.Open();
            }
            return sqlConnection;
        }
    }
}