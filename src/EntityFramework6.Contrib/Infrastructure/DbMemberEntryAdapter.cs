using EntityFramework6.Contrib.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbMemberEntryAdapter : IDbMemberEntry
    {
        private readonly DbMemberEntry _adaptee;
        private readonly Lazy<IDbEntityEntry> _dbEntityEntry;

        public DbMemberEntryAdapter(DbMemberEntry adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
            _dbEntityEntry = new Lazy<IDbEntityEntry>(() => new DbEntityEntryAdapter(adaptee.EntityEntry));
        }

        public object CurrentValue
        {
            get { return _adaptee.CurrentValue; }
            set { _adaptee.CurrentValue = value; }
        }

        public IDbEntityEntry EntityEntry => _dbEntityEntry.Value;
        public string Name => _adaptee.Name;

        public IDbMemberEntry<TEntity, TElement> Cast<TEntity, TElement>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public ICollection<IDbValidationError> GetValidationErrors()
        {
            throw new NotImplementedException();
        }
    }
}