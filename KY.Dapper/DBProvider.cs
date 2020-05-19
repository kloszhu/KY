using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KY.Dapper
{
    public abstract class DBProvider
    {
       
        public virtual IDbConnection DbConnection { get; set; }

        public static void DataBaseProvider(IDatabaseOption databaseConfiguration) {
            
        }
    }
}
