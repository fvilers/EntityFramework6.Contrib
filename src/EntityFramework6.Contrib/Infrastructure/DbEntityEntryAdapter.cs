using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    public class DbEntityEntryAdapter : IDbEntityEntry
    {
        private readonly DbEntityEntry _adaptee;

        public DbEntityEntryAdapter(DbEntityEntry adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}