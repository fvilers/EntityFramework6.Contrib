using EntityFramework6.Contrib.Infrastructure;
using System.Collections.Generic;

namespace EntityFramework6.Contrib.Validation
{
    public interface IDbEntityValidationResult
    {
        IDbEntityEntry Entry { get; }
        bool IsValid { get; }
        ICollection<IDbValidationError> ValidationErrors { get; }
    }
}