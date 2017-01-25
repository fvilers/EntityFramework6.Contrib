using EntityFramework6.Contrib.Validation;
using System.Collections.Generic;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbMemberEntry
    {
        object CurrentValue { get; set; }
        IDbEntityEntry EntityEntry { get; }
        string Name { get; }
        
        ICollection<IDbValidationError> GetValidationErrors();
    }
}