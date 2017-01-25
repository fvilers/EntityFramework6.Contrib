using EntityFramework6.Contrib.Infrastructure;
using EntityFramework6.Contrib.Validation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EntityFramework6.Contrib
{
    public class DbContextContrib : DbContext, IDbContext
    {
        private Lazy<IDbChangeTracker> _changeTracker;
        private Lazy<IDbContextConfiguration> _configuration;
        private Lazy<IDatabase> _database;

        public DbContextContrib()
        {
            Initialize();
        }

        public DbContextContrib(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Initialize();
        }

        public DbContextContrib(DbCompiledModel model)
            : base(model)
        {
            Initialize();
        }

        public DbContextContrib(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            Initialize();
        }

        public DbContextContrib(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
            Initialize();
        }

        public DbContextContrib(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
            Initialize();
        }

        public DbContextContrib(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            Initialize();
        }

        public new IDbChangeTracker ChangeTracker => _changeTracker.Value;
        public new IDbContextConfiguration Configuration => _configuration.Value;
        public new IDatabase Database => _database.Value;

        public new IDbEntityEntry Entry(object entity)
        {
            return new DbEntityEntryAdapter(base.Entry(entity));
        }

        public new IDbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return new DbEntityEntryAdapter<TEntity>(base.Entry(entity));
        }

        public new IEnumerable<IDbEntityValidationResult> GetValidationErrors()
        {
            return base.GetValidationErrors().Select(validationError => new DbEntityValidationResultAdapter(validationError)).ToArray();
        }

        public void OnModelCreating(IDbModelBuilder modelBuilder)
        {
            var adapter = modelBuilder as DbModelBuilderAdapter;

            if (adapter == null)
            {
                throw new NotSupportedException();
            }

            base.OnModelCreating(adapter.Adaptee);
        }

        public new IDbSet Set(Type entityType)
        {
            return new DbSetAdapter(base.Set(entityType));
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public bool ShouldValidateEntity(IDbEntityEntry entityEntry)
        {
            var adapter = entityEntry as DbEntityEntryAdapter;

            if (adapter == null)
            {
                throw new NotSupportedException();
            }

            return base.ShouldValidateEntity(adapter.Adaptee);
        }

        public IDbEntityValidationResult ValidateEntity(IDbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var adapter = entityEntry as DbEntityEntryAdapter;

            if (adapter == null)
            {
                throw new NotSupportedException();
            }

            return new DbEntityValidationResultAdapter(base.ValidateEntity(adapter.Adaptee, items));
        }

        private void Initialize()
        {
            _changeTracker = new Lazy<IDbChangeTracker>(() => new DbChangeTrackerAdapter(base.ChangeTracker));
            _configuration = new Lazy<IDbContextConfiguration>(() => new DbContextConfigurationAdapter(base.Configuration));
            _database = new Lazy<IDatabase>(() => new DatabaseAdapter(base.Database));
        }
    }
}
