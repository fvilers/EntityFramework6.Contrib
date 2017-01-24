using System.Collections.Generic;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbChangeTracker
    {
        void DetectChanges();
        IEnumerable<IDbEntityEntry> Entries();
        IEnumerable<IDbEntityEntry<TEntity>> Entries<TEntity>() where TEntity : class;
        bool HasChanges();
    }
}