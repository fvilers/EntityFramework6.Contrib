using EntityFramework6.Contrib.Infrastructure;
using System;
using System.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib
{
    public interface IDatabase
    {
        int? CommandTimeout { get; set; }
        IDbConnection Connection { get; }
        Action<string> Log { get; set; }

        IDbContextTransaction BeginTransaction();
        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
        bool CompatibleWithModel(bool throwIfNoMetadata);
        void Create();
        bool CreateIfNotExists();
        bool Delete();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(TransactionalBehavior transactionalBehavior, string sql, CancellationToken cancellationToken, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters);
        bool Exists();
        void Initialize(bool force);
        IDbRawSqlQuery SqlQuery(Type elementType, string sql, params object[] parameters);
        IDbRawSqlQuery<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
        void UseTransaction(IDbTransaction transaction);
    }
}