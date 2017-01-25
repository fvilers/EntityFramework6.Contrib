using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbCollectionEntryAdapter<TEntity, TElement> : DbMemberEntryAdapter<TEntity, ICollection<TElement>>, IDbCollectionEntry<TEntity, TElement>
        where TEntity : class
    {
        private readonly DbCollectionEntry<TEntity, TElement> _adaptee;

        public DbCollectionEntryAdapter(DbCollectionEntry<TEntity, TElement> adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}