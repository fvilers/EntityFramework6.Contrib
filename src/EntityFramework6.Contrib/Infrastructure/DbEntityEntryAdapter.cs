using EntityFramework6.Contrib.Validation;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbEntityEntryAdapter : IDbEntityEntry
    {
        public DbEntityEntry Adaptee { get; }

        private readonly Lazy<IDbPropertyValues> _currentValues;
        private readonly Lazy<IDbPropertyValues> _orignalValues;

        public DbEntityEntryAdapter(DbEntityEntry adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            Adaptee = adaptee;
            _currentValues = new Lazy<IDbPropertyValues>(() => new DbPropertyValuesAdapter(adaptee.CurrentValues));
            _orignalValues = new Lazy<IDbPropertyValues>(() => new DbPropertyValuesAdapter(adaptee.OriginalValues));
        }

        public IDbPropertyValues CurrentValues => _currentValues.Value;
        public object Entity => Adaptee.Entity;
        public IDbPropertyValues OriginalValues => _orignalValues.Value;

        public EntityState State
        {
            get { return Adaptee.State; }
            set { Adaptee.State = value; }
        }

        public IDbEntityEntry<TEntity> Cast<TEntity>() where TEntity : class
        {
            return new DbEntityEntryAdapter<TEntity>(Adaptee.Cast<TEntity>());
        }

        public IDbCollectionEntry Collection(string navigationProperty)
        {
            return new DbCollectionEntryAdapter(Adaptee.Collection(navigationProperty));
        }

        public IDbComplexPropertyEntry ComplexProperty(string propertyName)
        {
            return new DbComplexPropertyEntryAdapter(Adaptee.ComplexProperty(propertyName));
        }

        public IDbPropertyValues GetDatabaseValues()
        {
            return new DbPropertyValuesAdapter(Adaptee.GetDatabaseValues());
        }

        public async Task<IDbPropertyValues> GetDatabaseValuesAsync()
        {
            return new DbPropertyValuesAdapter(
                await Adaptee.GetDatabaseValuesAsync().ConfigureAwait(false)
            );
        }

        public async Task<IDbPropertyValues> GetDatabaseValuesAsync(CancellationToken cancellationToken)
        {
            return new DbPropertyValuesAdapter(
                await Adaptee.GetDatabaseValuesAsync(cancellationToken).ConfigureAwait(false)
            );
        }

        public IDbEntityValidationResult GetValidationResult()
        {
            return new DbEntityValidationResultAdapter(Adaptee.GetValidationResult());
        }

        public IDbMemberEntry Member(string propertyName)
        {
            return new DbMemberEntryAdapter(Adaptee.Member(propertyName));
        }

        public IDbPropertyEntry Property(string propertyName)
        {
            return new DbPropertyEntryAdapter(Adaptee.Property(propertyName));
        }

        public IDbReferenceEntry Reference(string navigationProperty)
        {
            return new DbReferenceEntryAdapter(Adaptee.Reference(navigationProperty));
        }

        public void Reload()
        {
            Adaptee.Reload();
        }

        public Task ReloadAsync()
        {
            return Adaptee.ReloadAsync();
        }

        public Task ReloadAsync(CancellationToken cancellationToken)
        {
            return Adaptee.ReloadAsync(cancellationToken);
        }
    }
}