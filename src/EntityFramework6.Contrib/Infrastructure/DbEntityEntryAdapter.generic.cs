using EntityFramework6.Contrib.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbEntityEntryAdapter<TEntity> : IDbEntityEntry<TEntity>
        where TEntity : class
    {
        private readonly DbEntityEntry<TEntity> _adaptee;
        private readonly Lazy<IDbPropertyValues> _currentValues;
        private readonly Lazy<IDbPropertyValues> _orignalValues;

        public DbEntityEntryAdapter(DbEntityEntry<TEntity> adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
            _currentValues = new Lazy<IDbPropertyValues>(() => new DbPropertyValuesAdapter(adaptee.CurrentValues));
            _orignalValues = new Lazy<IDbPropertyValues>(() => new DbPropertyValuesAdapter(adaptee.OriginalValues));
        }

        public IDbPropertyValues CurrentValues => _currentValues.Value;
        public TEntity Entity => _adaptee.Entity;
        public IDbPropertyValues OriginalValues => _orignalValues.Value;

        public EntityState State
        {
            get { return _adaptee.State; }
            set { _adaptee.State = value; }
        }

        public IDbCollectionEntry Collection(string navigationProperty)
        {
            return new DbCollectionEntryAdapter(_adaptee.Collection(navigationProperty));
        }

        public IDbCollectionEntry<TEntity, TElement> Collection<TElement>(Expression<Func<TEntity, ICollection<TElement>>> navigationProperty) where TElement : class
        {
            return new DbCollectionEntryAdapter<TEntity, TElement>(_adaptee.Collection(navigationProperty));
        }

        public IDbCollectionEntry<TEntity, TElement> Collection<TElement>(string navigationProperty) where TElement : class
        {
            return new DbCollectionEntryAdapter<TEntity, TElement>(_adaptee.Collection<TElement>(navigationProperty));
        }

        public IDbComplexPropertyEntry ComplexProperty(string propertyName)
        {
            return new DbComplexPropertyEntryAdapter(_adaptee.ComplexProperty(propertyName));
        }

        public IDbComplexPropertyEntry<TEntity, TComplexProperty> ComplexProperty<TComplexProperty>(Expression<Func<TEntity, TComplexProperty>> property)
        {
            return new DbComplexPropertyEntryAdapter<TEntity, TComplexProperty>(_adaptee.ComplexProperty(property));
        }

        public IDbComplexPropertyEntry<TEntity, TComplexProperty> ComplexProperty<TComplexProperty>(string propertyName)
        {
            return new DbComplexPropertyEntryAdapter<TEntity, TComplexProperty>(_adaptee.ComplexProperty<TComplexProperty>(propertyName));
        }

        public bool Equals(IDbEntityEntry<TEntity> other)
        {
            var adapter = other as DbEntityEntryAdapter<TEntity>;

            if (adapter == null)
            {
                throw new NotSupportedException();
            }

            return _adaptee.Equals(adapter._adaptee);
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

        public IDbMemberEntry<TEntity, TMember> Member<TMember>(string propertyName)
        {
            return new DbMemberEntryAdapter<TEntity, TMember>(_adaptee.Member<TMember>(propertyName));
        }

        public IDbPropertyEntry Property(string propertyName)
        {
            return new DbPropertyEntryAdapter(_adaptee.Property(propertyName));
        }

        public IDbPropertyEntry<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            return new DbPropertyEntryAdapter<TEntity, TProperty>(_adaptee.Property(property));
        }

        public IDbPropertyEntry<TEntity, TProperty> Property<TProperty>(string propertyName)
        {
            return new DbPropertyEntryAdapter<TEntity, TProperty>(_adaptee.Property<TProperty>(propertyName));
        }

        public IDbReferenceEntry Reference(string navigationProperty)
        {
            return new DbReferenceEntryAdapter(_adaptee.Reference(navigationProperty));
        }

        public IDbReferenceEntry<TEntity, TProperty> Reference<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty) where TProperty : class
        {
            return new DbReferenceEntryAdapter<TEntity, TProperty>(_adaptee.Reference(navigationProperty));
        }

        public IDbReferenceEntry<TEntity, TProperty> Reference<TProperty>(string navigationProperty) where TProperty : class
        {
            return new DbReferenceEntryAdapter<TEntity, TProperty>(_adaptee.Reference<TProperty>(navigationProperty));
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