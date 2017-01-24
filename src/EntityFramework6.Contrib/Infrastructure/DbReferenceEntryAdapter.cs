using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbReferenceEntryAdapter : DbMemberEntryAdapter, IDbReferenceEntry
    {
        private readonly DbReferenceEntry _adaptee;

        public DbReferenceEntryAdapter(DbReferenceEntry adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}