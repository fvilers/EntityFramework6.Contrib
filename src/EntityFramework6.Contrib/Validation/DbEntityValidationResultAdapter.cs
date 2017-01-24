using EntityFramework6.Contrib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace EntityFramework6.Contrib.Validation
{
    internal class DbEntityValidationResultAdapter : IDbEntityValidationResult
    {
        private readonly DbEntityValidationResult _adaptee;
        private readonly Lazy<IDbEntityEntry> _entry;
        private readonly Lazy<ICollection<IDbValidationError>> _validationErrors;

        public DbEntityValidationResultAdapter(DbEntityValidationResult adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
            _entry = new Lazy<IDbEntityEntry>(() => new DbEntityEntryAdapter(_adaptee.Entry));
            _validationErrors = new Lazy<ICollection<IDbValidationError>>(
                () => _adaptee.ValidationErrors.Select(validationError => new DbValidationErrorAdapter(validationError)).ToArray()
            );
        }

        public IDbEntityEntry Entry => _entry.Value;
        public bool IsValid => _adaptee.IsValid;
        public ICollection<IDbValidationError> ValidationErrors => _validationErrors.Value;
    }
}