using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KY.DapperTest
{
    public class MyService<T>
    {
        public virtual List<T> GetMoreParamesPagedList<TKey>(this IEnumerable<T> db, int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy)
        {
            return db.Where(whereLambda.Compile()).AsQueryable().OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
