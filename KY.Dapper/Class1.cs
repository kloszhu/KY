using KY.Infrastructure;
using System;
using System.Data;

namespace KY.Dapper
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private IDbConnection _connection;
        public bool Add(T model)
        {
            int? result;
            using (_connection = DbClient.OpenConnection())
            {
                result = _connection.Insert(model);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool Delete(int Id)
        {
            int? result;
            using (_connection = DbClient.OpenConnection())
            {
                result = _connection.Delete<T>(Id);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteList(string strWhere, object parameters)
        {
            int? result;
            using (_connection = DbClient.OpenConnection())
            {
                result = _connection.DeleteList<T>(strWhere, parameters);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public IEnumerable<T> GetListPage(int pageNum, int rowsNum, string strWhere, string orderBy, object parameters)
        {
            using (_connection = DbClient.OpenConnection())
            {
                return _connection.GetListPaged<T>(pageNum, rowsNum, strWhere, orderBy, parameters); ;
            }
        }


        public T GetModel(int Id)
        {
            using (_connection = DbClient.OpenConnection())
            {
                return _connection.Get<T>(Id);
            }
        }


        public IEnumerable<T> GetModelList(string strWhere, object parameters)
        {
            using (_connection = DbClient.OpenConnection())
            {
                return _connection.GetList<T>(strWhere, parameters);
            }
        }


        public bool Update(T model)
        {
            int? result;
            using (_connection = DbClient.OpenConnection())
            {
                result = _connection.Update(model);
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

