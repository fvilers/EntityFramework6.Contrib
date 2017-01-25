using EntityFramework6.Contrib.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbComplexPropertyEntryAdapter<TEntity, TComplexProperty> : IDbComplexPropertyEntry<TEntity, TComplexProperty>
        where TEntity : class
    {
        private readonly DbComplexPropertyEntry _adapter;

        public DbComplexPropertyEntryAdapter(DbComplexPropertyEntry adapter)
        {
            if (adapter == null) throw new ArgumentNullException(nameof(adapter));
            _adapter = adapter;
        }

        public TComplexProperty CurrentValue
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbEntityEntry<TEntity> EntityEntry
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<IDbValidationError> GetValidationErrors()
        {
            throw new NotImplementedException();
        }
    }
}