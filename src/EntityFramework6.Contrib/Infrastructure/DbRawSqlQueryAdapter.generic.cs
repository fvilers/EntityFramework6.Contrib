using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    public class DbRawSqlQueryAdapter<TElement> : IDbRawSqlQuery<TElement>
    {
        private readonly DbRawSqlQuery<TElement> _adaptee;

        public DbRawSqlQueryAdapter(DbRawSqlQuery<TElement> adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}