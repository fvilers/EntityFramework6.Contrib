using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbPropertyEntryAdapter : DbMemberEntryAdapter, IDbPropertyEntry
    {
        private readonly DbPropertyEntry _adaptee;

        public DbPropertyEntryAdapter(DbPropertyEntry adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}