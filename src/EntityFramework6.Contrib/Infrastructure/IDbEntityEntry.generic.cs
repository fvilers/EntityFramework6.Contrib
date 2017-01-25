using EntityFramework6.Contrib.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbEntityEntry<TEntity> : IEquatable<IDbEntityEntry<TEntity>>
        where TEntity : class
    {
        IDbPropertyValues CurrentValues { get; }
        TEntity Entity { get; }
        IDbPropertyValues OriginalValues { get; }
        EntityState State { get; set; }

        IDbCollectionEntry Collection(string navigationProperty);
        IDbCollectionEntry<TEntity, TElement> Collection<TElement>(Expression<Func<TEntity, ICollection<TElement>>> navigationProperty) where TElement : class;
        IDbCollectionEntry<TEntity, TElement> Collection<TElement>(string navigationProperty) where TElement : class;
        IDbComplexPropertyEntry ComplexProperty(string propertyName);
        IDbComplexPropertyEntry<TEntity, TComplexProperty> ComplexProperty<TComplexProperty>(Expression<Func<TEntity, TComplexProperty>> property);
        IDbComplexPropertyEntry<TEntity, TComplexProperty> ComplexProperty<TComplexProperty>(string propertyName);
        IDbPropertyValues GetDatabaseValues();
        Task<IDbPropertyValues> GetDatabaseValuesAsync();
        Task<IDbPropertyValues> GetDatabaseValuesAsync(CancellationToken cancellationToken);
        IDbEntityValidationResult GetValidationResult();
        IDbMemberEntry Member(string propertyName);
        IDbMemberEntry<TEntity, TMember> Member<TMember>(string propertyName);
        IDbPropertyEntry Property(string propertyName);
        IDbPropertyEntry<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> property);
        IDbPropertyEntry<TEntity, TProperty> Property<TProperty>(string propertyName);
        IDbReferenceEntry Reference(string navigationProperty);
        IDbReferenceEntry<TEntity, TProperty> Reference<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty) where TProperty : class;
        IDbReferenceEntry<TEntity, TProperty> Reference<TProperty>(string navigationProperty) where TProperty : class;
        void Reload();
        Task ReloadAsync();
        Task ReloadAsync(CancellationToken cancellationToken);
    }
}