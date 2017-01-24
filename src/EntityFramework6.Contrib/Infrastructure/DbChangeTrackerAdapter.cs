using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbChangeTrackerAdapter : IDbChangeTracker
    {
        private readonly DbChangeTracker _adaptee;

        public DbChangeTrackerAdapter(DbChangeTracker adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }

        public void DetectChanges()
        {
            _adaptee.DetectChanges();
        }

        public IEnumerable<IDbEntityEntry> Entries()
        {
            return _adaptee.Entries().Select(entry => new DbEntityEntryAdapter(entry)).ToArray();
        }

        public IEnumerable<IDbEntityEntry<TEntity>> Entries<TEntity>() where TEntity : class
        {
            return _adaptee.Entries<TEntity>().Select(entry => new DbEntityEntryAdapter<TEntity>(entry)).ToArray();
        }

        public bool HasChanges()
        {
            return _adaptee.HasChanges();
        }
    }
}