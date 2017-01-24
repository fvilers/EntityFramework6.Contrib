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
        private readonly DbEntityEntry _adaptee;
        private readonly Lazy<IDbPropertyValues> _currentValues;
        private readonly Lazy<IDbPropertyValues> _orignalValues;

        public DbEntityEntryAdapter(DbEntityEntry adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
            _currentValues = new Lazy<IDbPropertyValues>(() => new DbPropertyValuesAdapter(adaptee.CurrentValues));
            _orignalValues = new Lazy<IDbPropertyValues>(() => new DbPropertyValuesAdapter(adaptee.OriginalValues));
        }

        public IDbPropertyValues CurrentValues => _currentValues.Value;
        public object Entity => _adaptee.Entity;
        public IDbPropertyValues OriginalValues => _orignalValues.Value;

        public EntityState State
        {
            get { return _adaptee.State; }
            set { _adaptee.State = value; }
        }

        public IDbEntityEntry<TEntity> Cast<TEntity>() where TEntity : class
        {
            return new DbEntityEntryAdapter<TEntity>(_adaptee.Cast<TEntity>());
        }

        public IDbCollectionEntry Collection(string navigationProperty)
        {
            return new DbCollectionEntryAdapter(_adaptee.Collection(navigationProperty));
        }

        public IDbComplexPropertyEntry ComplexProperty(string propertyName)
        {
            return new DbComplexPropertyEntryAdapter(_adaptee.ComplexProperty(propertyName));
        }

        public IDbPropertyValues GetDatabaseValues()
        {
            return new DbPropertyValuesAdapter(_adaptee.GetDatabaseValues());
        }

        public async Task<IDbPropertyValues> GetDatabaseValuesAsync()
        {
            return new DbPropertyValuesAdapter(
                await _adaptee.GetDatabaseValuesAsync().ConfigureAwait(false)
            );
        }

        public async Task<IDbPropertyValues> GetDatabaseValuesAsync(CancellationToken cancellationToken)
        {
            return new DbPropertyValuesAdapter(
                await _adaptee.GetDatabaseValuesAsync(cancellationToken).ConfigureAwait(false)
            );
        }

        public IDbEntityValidationResult GetValidationResult()
        {
            return new DbEntityValidationResultAdapter(_adaptee.GetValidationResult());
        }

        public IDbMemberEntry Member(string propertyName)
        {
            return new DbMemberEntryAdapter(_adaptee.Member(propertyName));
        }

        public IDbPropertyEntry Property(string propertyName)
        {
            return new DbPropertyEntryAdapter(_adaptee.Property(propertyName));
        }

        public IDbReferenceEntry Reference(string navigationProperty)
        {
            return new DbReferenceEntryAdapter(_adaptee.Reference(navigationProperty));
        }

        public void Reload()
        {
            _adaptee.Reload();
        }

        public Task ReloadAsync()
        {
            return _adaptee.ReloadAsync();
        }

        public Task ReloadAsync(CancellationToken cancellationToken)
        {
            return _adaptee.ReloadAsync(cancellationToken);
        }
    }
}