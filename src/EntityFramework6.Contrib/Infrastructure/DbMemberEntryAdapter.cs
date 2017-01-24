using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbMemberEntryAdapter : IDbMemberEntry
    {
        private readonly DbMemberEntry _adaptee;

        public DbMemberEntryAdapter(DbMemberEntry adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}