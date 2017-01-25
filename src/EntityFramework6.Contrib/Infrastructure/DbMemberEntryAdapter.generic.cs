using EntityFramework6.Contrib.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbMemberEntryAdapter<TEntity, TProperty> : IDbMemberEntry<TEntity, TProperty>
        where TEntity : class
    {
        private readonly DbMemberEntry<TEntity, TProperty> _adaptee;
        private readonly Lazy<IDbEntityEntry<TEntity>> _dbEntityEntry;

        public DbMemberEntryAdapter(DbMemberEntry<TEntity, TProperty> adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
            _dbEntityEntry = new Lazy<IDbEntityEntry<TEntity>>(() => new DbEntityEntryAdapter<TEntity>(adaptee.EntityEntry));
        }

        public TProperty CurrentValue
        {
            get { return _adaptee.CurrentValue; }
            set { _adaptee.CurrentValue = value; }
        }

        public IDbEntityEntry<TEntity> EntityEntry => _dbEntityEntry.Value;
        public string Name => _adaptee.Name;

        public ICollection<IDbValidationError> GetValidationErrors()
        {
            return _adaptee.GetValidationErrors().Select(validationError => new DbValidationErrorAdapter(validationError)).ToArray();
        }
    }
}