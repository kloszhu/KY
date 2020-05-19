using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace KY.DapperTest
{
    public static class StaticConfig
    {
        public static string ConnectString = "data source=.;database=myauth;user id=sa;password=sa123456";
        public static IDbConnection DbConnection = new SqlConnection(ConnectString);
    }
}
