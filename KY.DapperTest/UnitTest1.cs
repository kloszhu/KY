using System;
using Xunit;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace KY.DapperTest
{
    public class UnitTest1
    {

        public IDbConnection GetConnection() {
            return StaticConfig.DbConnection;
        }
        /// <summary>
        /// 经过测试，实体必须和sql一致。
        /// </summary>
        [Fact]
        public void Test1()
        {
            SqlConnection connection = new SqlConnection(StaticConfig.ConnectString);
            Student student = new Student();
            student.Student_id = 123;
            student.Name = "Name";

        }
    }
}
