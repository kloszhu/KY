using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace KY.Dapper
{
    //public class Dapper
    //{

    //    public IDbConnection dbConnection => new SqlConnection(_sqlConnectionString);
    //    public List<T> Query<T>(string AllSql, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        return db.Query<T>(AllSql, obj).ToList();
    //    }

    //    public List<T> PartQueryPage<T>(string partSql, Pagination page, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        page.count = GetCount(partSql, obj);
    //        if (page.sortBy == null || page.sortBy.Count() == 0)
    //        {
    //            partSql += " ORDER BY 1 ";
    //        }
    //        else
    //        {
    //            List<string> sorting = new List<string>();
    //            for (int i = 0; i < page.sortBy.Count(); i++)
    //            {
    //                sorting.Add(string.Format("{0} {1}", page.sortBy[i], page.sortDesc[i] ? "desc" : "asc"));
    //            }
    //            partSql += $" order by {string.Join(",", sorting.ToArray())}";

    //        }
    //        partSql += String.Format(" offset {0} row fetch next {1} rows only", page.fromIndex, page.itemsPerPage);
    //        return db.Query<T>(partSql, obj).ToList();
    //    }


    //    public int Update<T>(T model, string tableName)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string allSql = String.Empty;
    //        var PrimaryKeyList = typeof(T).GetProperties().Where(a => a.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
    //        if (PrimaryKeyList == null)
    //        {
    //            throw new Exception($"表名'{typeof(T).Name}'无主键，不能更新");
    //        }
    //        string PrimaryKeyName = PrimaryKeyList.FirstOrDefault().Name;
    //        ///过滤掉Identity和主键
    //        ///获得当前类型
    //        T t = model;
    //        List<String> UpdateItem = new List<string>();
    //        foreach (System.Reflection.PropertyInfo item in model.GetType().GetProperties())
    //        {
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(IdentityAttribute))).Count() > 0)
    //            {
    //                continue;
    //            }
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(PrimaryKeyAttribute))).Count() > 0)
    //            {
    //                continue;
    //            }
    //            //判断属性是否有值有值就更新
    //            if (item.GetValue(t, null) == null)
    //            {
    //                continue;
    //            }
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(IgnoreAttribute))).Count() > 0)
    //            {
    //                continue;
    //            }
    //            UpdateItem.Add(item.Name + "=@" + item.Name);
    //        }

    //        allSql = $"update dbo.{tableName} set {String.Join(",", UpdateItem.ToArray())} where {PrimaryKeyName}=@{PrimaryKeyName}";
    //        return db.Execute(allSql, model);
    //    }

    //    public DataTable PartQueryPage(string partSql, Pagination page, Dictionary<string, object> obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string countsql = $"select count(1) from  ( {partSql}  ) GetCount";
    //        page.count = Convert.ToInt32(db.ExecuteScalar(countsql, obj));
    //        if (page.sortBy == null || page.sortBy.Count() == 0)
    //        {
    //            partSql += " ORDER BY 1 ";
    //        }
    //        else
    //        {
    //            List<string> sorting = new List<string>();
    //            for (int i = 0; i < page.sortBy.Count(); i++)
    //            {
    //                sorting.Add(string.Format("{0} {1}", page.sortBy[i], page.sortDesc[i] ? "desc" : "asc"));
    //            }
    //            partSql += $" order by {string.Join(",", sorting.ToArray())}";

    //        }
    //        partSql += String.Format(" offset {0} row fetch next {1} rows only", page.fromIndex, page.itemsPerPage);
    //        return QueryTable(partSql, obj);
    //    }


    //    public T GetModel<T>(string AndWhere = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"select top 1 * from  " + typeof(T).Name;
    //        if (AndWhere != null)
    //        {
    //            sql += " Where 1=1 " + AndWhere;
    //        }
    //        return db.Query<T>(sql, obj).FirstOrDefault();
    //    }



    //    public List<T> GetList<T>(string AndWhere = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"select * from  " + typeof(T).Name + "(NOLOCK) ";
    //        if (AndWhere != null)
    //        {
    //            sql += " Where 1=1 " + AndWhere;
    //        }
    //        return db.Query<T>(sql, obj).ToList();
    //    }

    //    public Task<IEnumerable<T>> ListNoDeleteAnsy<T>(string AndWhere = null, string orderby = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"select * from  " + typeof(T).Name + " where 1=1 ";
    //        if (AndWhere != null)
    //        {
    //            sql += AndWhere;
    //        }
    //        foreach (System.Reflection.PropertyInfo item in typeof(T).GetProperties())
    //        {
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(IsDeleteAttribute))).Count() > 0)
    //            {
    //                sql += $" and {item.Name}=0 ";
    //            }

    //        }
    //        if (orderby != null)
    //        {
    //            sql += orderby;
    //        }

    //        return db.QueryAsync<T>(sql, obj);
    //    }

    //    public List<T> ListNoDelete<T>(string AndWhere = null, string orderby = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"select * from  " + typeof(T).Name + "  where 1=1 ";
    //        if (AndWhere != null)
    //        {
    //            sql += AndWhere;
    //        }
    //        foreach (System.Reflection.PropertyInfo item in typeof(T).GetProperties())
    //        {
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(IsDeleteAttribute))).Count() > 0)
    //            {
    //                sql += $" and {item.Name}=0 ";
    //            }

    //        }
    //        if (orderby != null)
    //        {
    //            sql += " order by " + orderby;
    //        }

    //        return db.Query<T>(sql, obj).ToList();
    //    }

    //    public List<T> GetListByPage<T>(int fromIndex, int EndIndex, string[] orderby, string AndWhere = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"select * from  " + typeof(T).Name;
    //        if (AndWhere != null)
    //        {
    //            sql += " Where 1=1 " + AndWhere;
    //        }
    //        if (orderby.Count() == 0)
    //        {
    //            sql += "order by 1 ";
    //        }
    //        else
    //        {
    //            sql += $"order by{string.Join(",", orderby.ToArray())} ";
    //        }
    //        sql += String.Format(" offset {0} row fetch next {1} rows only", fromIndex, EndIndex);
    //        return db.Query<T>(sql, obj).ToList();
    //    }
    //    public List<T> GetListByPage<T>(Pagination page, string AndWhere = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"select * from  " + typeof(T).Name;
    //        if (AndWhere != null)
    //        {
    //            sql += " Where 1=1 " + AndWhere;
    //        }
    //        page.count = GetCount(sql.ToString(), obj);
    //        if (page.sortBy == null || page.sortBy.Count() == 0)
    //        {
    //            sql += " ORDER BY 1 ";
    //        }
    //        else
    //        {
    //            List<string> sorting = new List<string>();
    //            for (int i = 0; i < page.sortBy.Count(); i++)
    //            {
    //                sorting.Add(string.Format("{0} {1}", page.sortBy[i], page.sortDesc[i] ? "desc" : "asc"));
    //            }
    //            sql += $" order by {string.Join(",", sorting.ToArray())}";

    //        }
    //        sql += String.Format(" offset {0} row fetch next {1} rows only", page.fromIndex, page.itemsPerPage);
    //        return db.Query<T>(sql, obj).ToList();
    //    }
    //    public bool Delete<T>(string AndWhere = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"delete from  " + typeof(T).Name;
    //        if (AndWhere != null)
    //        {
    //            sql += "  Where 1=1 " + AndWhere;
    //        }
    //        else
    //        {
    //            throw new Exception("不能批量删除");
    //        }
    //        return db.Execute(sql, obj) > 1 ? true : false;
    //    }

    //    public object ExequteScale(string sql, object obj)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        return db.ExecuteScalar(sql, obj);
    //    }

    //    public int Add<T>(T model)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        ///过滤掉Identity和主键
    //        ///
    //        List<String> FrontItem = new List<string>();
    //        List<String> EndItem = new List<string>();
    //        foreach (System.Reflection.PropertyInfo item in model.GetType().GetProperties())
    //        {
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(IdentityAttribute))).Count() > 0)
    //            {
    //                continue;
    //            }
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(PrimaryKeyAttribute))).Count() > 0 && item.GetValue(model, null) == null)
    //            {
    //                throw new Exception($"{typeof(T).Name}:'{item.Name}'主键为必填项不能为空!");
    //            }
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(NullAbleAttribute))).Count() > 0 && item.GetValue(model, null) == null)
    //            {
    //                throw new Exception($"{typeof(T).Name}:'{item.Name}'为必填项不能为空!");
    //            }

    //            FrontItem.Add(item.Name);
    //            EndItem.Add("@" + item.Name);
    //        }

    //        string sql = $"insert into {typeof(T).Name} ({String.Join(",", FrontItem.ToArray())}) values ({String.Join(",", EndItem.ToArray())});";
    //        return db.Execute(sql, model);
    //    }


    //    public DataTable QueryTable(string sql, Dictionary<string, object> parampter = null)
    //    {
    //        DataTable dt = new DataTable();
    //        IDbConnection db = new SqlConnection(_sqlConnectionString);
    //        if (db.State == ConnectionState.Closed)
    //        {
    //            db.Open();
    //        }
    //        var reader = db.ExecuteReader(sql, parampter.ConvertToDynamicParameters());
    //        dt.Load(reader);
    //        db.Close();

    //        return dt;

    //    }
    //    public async Task<DataTable> QueryTableAnsy(string sql, Dictionary<string, object> parampter = null)
    //    {
    //        DataTable dt = new DataTable();
    //        IDbConnection db = new SqlConnection(_sqlConnectionString);
    //        if (db.State == ConnectionState.Closed)
    //        {
    //            db.Open();
    //        }
    //        Task<IDataReader> reader = db.ExecuteReaderAsync(sql, parampter.ConvertToDynamicParameters());

    //        dt.Load(await reader);
    //        db.Close();

    //        return dt;
    //    }
    //    public int Add<T>(List<T> model)
    //    {
    //        int i = 0;
    //        foreach (var item in model)
    //        {
    //            Add<T>(item);
    //            i++;
    //        }
    //        return i;

    //    }

    //    public bool Exequte(string sql, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        return db.Execute(sql, obj) > 0 ? true : false;
    //    }

    //    public int Update<T>(T model)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string allSql = String.Empty;
    //        var PrimaryKeyList = typeof(T).GetProperties().Where(a => a.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
    //        if (PrimaryKeyList == null)
    //        {
    //            throw new Exception($"表名'{typeof(T).Name}'无主键，不能更新");
    //        }
    //        string PrimaryKeyName = PrimaryKeyList.FirstOrDefault().Name;
    //        ///过滤掉Identity和主键
    //        ///获得当前类型
    //        T t = model;
    //        List<String> UpdateItem = new List<string>();
    //        foreach (System.Reflection.PropertyInfo item in model.GetType().GetProperties())
    //        {
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(IdentityAttribute))).Count() > 0)
    //            {
    //                continue;
    //            }
    //            if (item.GetCustomAttributes(true).Where(a => a.GetType().Equals(typeof(PrimaryKeyAttribute))).Count() > 0)
    //            {
    //                continue;
    //            }
    //            //判断属性是否有值有值就更新
    //            if (item.GetValue(t, null) == null)
    //            {
    //                continue;
    //            }
    //            UpdateItem.Add(item.Name + "=@" + item.Name);
    //        }

    //        allSql = $"update dbo.{typeof(T).Name} set {String.Join(",", UpdateItem.ToArray())} where {PrimaryKeyName}=@{PrimaryKeyName}";
    //        return db.Execute(allSql, model);

    //    }

    //    public T GetModel<T>(object id)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        var PrimaryKeyList = typeof(T).GetProperties().Where(a => a.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
    //        if (PrimaryKeyList == null)
    //        {
    //            throw new Exception($"表名'{typeof(T).Name}'无主键，不能操作查询");
    //        }
    //        string PrimaryKeyName = PrimaryKeyList.FirstOrDefault().Name;
    //        string sql = $"select top 1 * from  {typeof(T).Name} where {PrimaryKeyName}=@{PrimaryKeyName}";
    //        //Dictionary<string, object> valuePairs = new Dictionary<string, object>();
    //        //valuePairs.Add(PrimaryKeyName, id);
    //        DynamicParameters dynamicParameters = new DynamicParameters();
    //        dynamicParameters.Add(PrimaryKeyName, id);
    //        return db.Query<T>(sql, dynamicParameters).FirstOrDefault();
    //    }

    //    public bool Delete<T>(object id)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        var PrimaryKeyList = typeof(T).GetProperties().Where(a => a.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
    //        if (PrimaryKeyList == null)
    //        {
    //            throw new Exception($"表名'{typeof(T).Name}'无主键，不能操作删除");
    //        }
    //        string PrimaryKeyName = PrimaryKeyList.FirstOrDefault().Name;
    //        string sql = $"delete from  {typeof(T).Name} where {PrimaryKeyName}=@{PrimaryKeyName}";
    //        //Dictionary<string, object> valuePairs = new Dictionary<string, object>();
    //        //valuePairs.Add(PrimaryKeyName, id);
    //        DynamicParameters dynamicParameters = new DynamicParameters();
    //        dynamicParameters.Add(PrimaryKeyName, id);
    //        return db.Execute(sql, dynamicParameters) > 1 ? true : false;
    //    }
    //    public bool DeleteList<T>(List<T> models)
    //    {
    //        if (models.Count == 0)
    //        {
    //            return false;
    //        }
    //        var db = new SqlConnection(_sqlConnectionString);
    //        var PrimaryKeyList = typeof(T).GetProperties().Where(a => a.GetCustomAttributes(typeof(PrimaryKeyAttribute), true).Count() > 0);
    //        if (PrimaryKeyList == null)
    //        {
    //            throw new Exception($"表名'{typeof(T).Name}'无主键，不能操作删除");
    //        }
    //        string PrimaryKeyName = PrimaryKeyList.FirstOrDefault().Name;
    //        string sql = $"delete from  {typeof(T).Name} where {PrimaryKeyName} in @{PrimaryKeyName}";
    //        DynamicParameters dynamicParameters = new DynamicParameters();
    //        var lists = models.Select(a => a.GetType().GetProperty(PrimaryKeyName).GetValue(a, null)).ToArray();
    //        dynamicParameters.Add(PrimaryKeyName, lists);
    //        return db.Execute(sql, dynamicParameters) > 1 ? true : false;
    //    }

    //    public bool DeleteAll<T>(string AndWhere = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"delete from  " + typeof(T).Name;
    //        return db.ExecuteScalar<bool>(sql);
    //    }


    //    public bool Exists<T>(string AndWhere = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = $"select top 1 1 from  " + typeof(T).Name;
    //        if (AndWhere != null)
    //        {
    //            sql += "  Where 1=1 " + AndWhere;
    //        }
    //        return db.ExecuteScalar<bool>(sql, obj);
    //    }

    //    public bool Exists(string TableName, string AndWhere = null, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        string sql = "select top 1 1 from " + TableName;
    //        if (AndWhere != null)
    //        {
    //            sql += "  Where 1=1 " + AndWhere;
    //        }
    //        return db.ExecuteScalar<bool>(sql, obj);
    //    }

    //    public bool Exqute(string allSql, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        return db.Execute(allSql, obj) > 0 ? true : false;
    //    }
    //    public object ExecuteScalar(string allSql, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        return db.ExecuteScalar(allSql, obj);
    //    }
    //    public int GetCount(string sql, object obj = null)
    //    {
    //        using (IDbConnection db = new SqlConnection(_sqlConnectionString))
    //        {
    //            string countSql = sql;// "select count(1) from  ( " + sql + " ) GetCount";
    //            IEnumerable<object> data;
    //            if (obj == null)
    //                data = db.Query(countSql);
    //            else
    //                data = db.Query(countSql, obj);
    //            int count = 0;
    //            if (int.TryParse(data.Count().ToString(), out count))
    //            {
    //                return count;
    //            }
    //            else
    //            {
    //                return 0;
    //            }
    //        }
    //        //IDbConnection db = new SqlConnection(_sqlConnectionString);
    //        //if (db.State == ConnectionState.Closed)
    //        //{
    //        //    db.Open();
    //        //}
    //        //string countSql = sql;// "select count(1) from  ( " + sql + " ) GetCount";
    //        //object data;
    //        //if (obj == null)
    //        //    data = db.Execute(countSql);
    //        //else
    //        //    data = db.Execute(countSql, obj);
    //        //int count = 0;
    //        //if (int.TryParse(data.ToString(), out count))
    //        //{
    //        //    db.Close();
    //        //    return count;
    //        //}
    //        //else
    //        //{
    //        //    db.Close();
    //        //    return 0;
    //        //}
    //    }
    //    public T GetModelBySql<T>(string sql, object obj = null)
    //    {
    //        var db = new SqlConnection(_sqlConnectionString);
    //        return db.Query<T>(sql, obj).FirstOrDefault();
    //    }
    //}
}
