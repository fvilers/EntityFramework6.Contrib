using EntityFramework6.Contrib.Infrastructure;
using EntityFramework6.Contrib.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib
{
    public interface IDbContext
    {
        IDbChangeTracker ChangeTracker { get; }
        IDbContextConfiguration Configuration { get; }
        IDatabase Database { get; }

        IDbEntityEntry Entry(object entity);
        IDbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<IDbEntityValidationResult> GetValidationErrors();
        void OnModelCreating(IDbModelBuilder modelBuilder);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IDbSet Set(Type entityType);
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        bool ShouldValidateEntity(IDbEntityEntry entityEntry);
        IDbEntityValidationResult ValidateEntity(IDbEntityEntry entityEntry, IDictionary<object, object> items);
    }
}