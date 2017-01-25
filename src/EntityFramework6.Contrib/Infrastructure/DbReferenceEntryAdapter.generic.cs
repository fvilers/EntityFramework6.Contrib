using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbReferenceEntryAdapter<TEntity, TProperty> : DbMemberEntryAdapter<TEntity, TProperty>, IDbReferenceEntry<TEntity, TProperty>
        where TEntity : class
    {
        private readonly DbReferenceEntry<TEntity, TProperty> _adaptee;

        public DbReferenceEntryAdapter(DbReferenceEntry<TEntity, TProperty> adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}