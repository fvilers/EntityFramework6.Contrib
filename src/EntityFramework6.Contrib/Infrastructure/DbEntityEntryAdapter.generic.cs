using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbEntityEntryAdapter<TEntity> : IDbEntityEntry<TEntity>
        where TEntity : class
    {
        private readonly DbEntityEntry _adaptee;

        public DbEntityEntryAdapter(DbEntityEntry adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}