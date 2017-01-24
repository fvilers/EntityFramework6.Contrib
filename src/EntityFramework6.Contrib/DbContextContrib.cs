using EntityFramework6.Contrib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib
{
    // TODO: implement this
    public class DbContextContrib : DbContext, IDbContext
    {
        public new IDbChangeTracker ChangeTracker { get; }
        public new IDbContextConfiguration Configuration { get; }
        public new IDatabase Database { get; }

        public new IDbEntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }

        public new IDbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<IDbEntityValidationResult> GetValidationErrors()
        {
            throw new NotImplementedException();
        }

        public void OnModelCreating(IDbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public override int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public override Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public new IDbSet Set(Type entityType)
        {
            throw new NotImplementedException();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public bool ShouldValidateEntity(IDbEntityEntry entityEntry)
        {
            throw new NotImplementedException();
        }

        public IDbEntityValidationResult ValidateEntity(IDbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            throw new NotImplementedException();
        }
    }
}
