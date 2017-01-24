using EntityFramework6.Contrib.Validation;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbEntityEntry
    {
        IDbPropertyValues CurrentValues { get; }
        object Entity { get; }
        IDbPropertyValues OriginalValues { get; }
        EntityState State { get; set; }
        IDbEntityEntry<TEntity> Cast<TEntity>() where TEntity : class;
        IDbCollectionEntry Collection(string navigationProperty);
        IDbComplexPropertyEntry ComplexProperty(string propertyName);
        IDbPropertyValues GetDatabaseValues();
        Task<IDbPropertyValues> GetDatabaseValuesAsync();
        Task<IDbPropertyValues> GetDatabaseValuesAsync(CancellationToken cancellationToken);
        IDbEntityValidationResult GetValidationResult();
        IDbMemberEntry Member(string propertyName);
        IDbPropertyEntry Property(string propertyName);
        IDbReferenceEntry Reference(string navigationProperty);
        void Reload();
        Task ReloadAsync();
        Task ReloadAsync(CancellationToken cancellationToken);
    }
}