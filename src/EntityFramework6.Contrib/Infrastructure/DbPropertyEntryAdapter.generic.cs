using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbPropertyEntryAdapter<TEntity, TProperty> : DbMemberEntryAdapter<TEntity, TProperty>, IDbPropertyEntry<TEntity, TProperty>
        where TEntity : class
    {
        private readonly DbPropertyEntry<TEntity, TProperty> _adaptee;

        public DbPropertyEntryAdapter(DbPropertyEntry<TEntity, TProperty> adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}