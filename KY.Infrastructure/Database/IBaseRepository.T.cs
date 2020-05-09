using KY.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KY.Infrastructure
{
    public interface IBaseRepository<T,PrimaryKey> where T:IEntity<PrimaryKey>
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(T model);
        /// <summary>
        /// 根据ID删除一条数据
        /// </summary>
        bool Delete(PrimaryKey Id);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(T model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Save(T model);
        /// <summary>
        /// 根据ID获取实体对象
        /// </summary>
        T GetModel(PrimaryKey Id);
        /// <summary>
        /// 查询
        /// </summary>
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression);


        #endregion
    }
}

