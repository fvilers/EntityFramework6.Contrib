using EntityFramework6.Contrib.Infrastructure;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib
{
    public class DatabaseAdapter : IDatabase
    {
        private readonly Database _adaptee;

        public DatabaseAdapter(Database adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }

        public int? CommandTimeout
        {
            get { return _adaptee.CommandTimeout; }
            set { _adaptee.CommandTimeout = value; }
        }

        public IDbConnection Connection => _adaptee.Connection;

        public Action<string> Log
        {
            get { return _adaptee.Log; }
            set { _adaptee.Log = value; }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return new DbContextTransactionAdapter(_adaptee.BeginTransaction());
        }

        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new DbContextTransactionAdapter(_adaptee.BeginTransaction(isolationLevel));
        }

        public bool CompatibleWithModel(bool throwIfNoMetadata)
        {
            return _adaptee.CompatibleWithModel(throwIfNoMetadata);
        }

        public void Create()
        {
            _adaptee.Create();
        }

        public bool CreateIfNotExists()
        {
            return _adaptee.CreateIfNotExists();
        }

        public bool Delete()
        {
            return _adaptee.Delete();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _adaptee.ExecuteSqlCommand(sql, parameters);
        }

        public int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters)
        {
            return _adaptee.ExecuteSqlCommand(transactionalBehavior, sql, parameters);
        }

        public Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return _adaptee.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return _adaptee.ExecuteSqlCommandAsync(sql, parameters);
        }

        public Task<int> ExecuteSqlCommandAsync(TransactionalBehavior transactionalBehavior, string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return _adaptee.ExecuteSqlCommandAsync(transactionalBehavior, sql, cancellationToken, parameters);
        }

        public Task<int> ExecuteSqlCommandAsync(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters)
        {
            return _adaptee.ExecuteSqlCommandAsync(transactionalBehavior, sql, parameters);
        }

        public bool Exists()
        {
            return _adaptee.Exists();
        }

        public void Initialize(bool force)
        {
            _adaptee.Initialize(force);
        }

        public IDbRawSqlQuery SqlQuery(Type elementType, string sql, params object[] parameters)
        {
            return new DbRawSqlQueryAdapter(_adaptee.SqlQuery(elementType, sql, parameters));
        }

        public IDbRawSqlQuery<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return new DbRawSqlQueryAdapter<TElement>(_adaptee.SqlQuery<TElement>(sql, parameters));
        }

        public void UseTransaction(IDbTransaction transaction)
        {
            var concrete = transaction as DbTransaction;

            if (concrete == null)
            {
                throw new NotSupportedException();
            }

            _adaptee.UseTransaction(concrete);
        }
    }
}