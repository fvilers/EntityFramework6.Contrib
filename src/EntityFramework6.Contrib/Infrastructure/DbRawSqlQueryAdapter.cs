using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    public class DbRawSqlQueryAdapter : IDbRawSqlQuery
    {
        private readonly DbRawSqlQuery _adaptee;

        public DbRawSqlQueryAdapter(DbRawSqlQuery adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}