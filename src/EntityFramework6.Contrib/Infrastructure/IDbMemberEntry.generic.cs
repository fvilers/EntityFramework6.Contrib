using EntityFramework6.Contrib.Validation;
using System.Collections.Generic;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbMemberEntry<TEntity, TProperty>
        where TEntity : class
    {
        TProperty CurrentValue { get; set; }
        IDbEntityEntry<TEntity> EntityEntry { get; }
        string Name { get; }

        ICollection<IDbValidationError> GetValidationErrors();
    }
}