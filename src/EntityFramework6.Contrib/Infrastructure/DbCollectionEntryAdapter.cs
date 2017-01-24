using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbCollectionEntryAdapter : DbMemberEntryAdapter, IDbCollectionEntry
    {
        private readonly DbCollectionEntry _adaptee;

        public DbCollectionEntryAdapter(DbCollectionEntry adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}