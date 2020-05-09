using System;
using System.Collections.Generic;
using System.Text;

namespace KY.DataBase.Dapper
{
    //public class DapperEfRepositoryBase<TDbContext, TEntity, TPrimaryKey> : DapperRepositoryBase<TEntity, TPrimaryKey>
    //      where TEntity : class, IEntity<TPrimaryKey>

    //{
    //    private readonly IActiveTransactionProvider _activeTransactionProvider;
    //    private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;

    //    public DapperEfRepositoryBase(IActiveTransactionProvider activeTransactionProvider,
    //        ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
    //        : base(activeTransactionProvider)
    //    {
    //        _activeTransactionProvider = activeTransactionProvider;
    //        _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
    //    }

    //    public ActiveTransactionProviderArgs ActiveTransactionProviderArgs
    //    {
    //        get
    //        {
    //            return new ActiveTransactionProviderArgs
    //            {
    //                ["ContextType"] = typeof(TDbContext),
    //                ["MultiTenancySide"] = MultiTenancySide
    //            };
    //        }
    //    }

    //    public override DbConnection Connection => (DbConnection)_activeTransactionProvider.GetActiveConnection(ActiveTransactionProviderArgs);

    //    public override DbTransaction ActiveTransaction => (DbTransaction)_activeTransactionProvider.GetActiveTransaction(ActiveTransactionProviderArgs);

    //    public override int? Timeout => _currentUnitOfWorkProvider.Current?.Options.Timeout?.TotalSeconds.To<int>();
    //}
}
