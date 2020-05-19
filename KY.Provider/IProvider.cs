using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KY.Provider
{
    public interface DataBaseProvider<T>
    {
        T Get(object PrimaryKey);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression=null);
        int Update(T t);
        int Update(Expression<Func<T,object>> Data, Expression<Func<T, bool>> expression = null);
        int Delete(Expression<Func<T, bool>> expression=null);
        int Add(T t);
        int Count(Expression<Func<T, bool>> expression=null);
    }
}
