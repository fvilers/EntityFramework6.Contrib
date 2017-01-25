using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbPropertyEntryAdapter : DbMemberEntryAdapter, IDbPropertyEntry
    {
        private readonly DbPropertyEntry _adaptee;
        private readonly Lazy<IDbComplexPropertyEntry> _parentProperty;

        public DbPropertyEntryAdapter(DbPropertyEntry adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
            _parentProperty = new Lazy<IDbComplexPropertyEntry>(() => new DbComplexPropertyEntryAdapter(adaptee.ParentProperty));
        }

        public bool IsModified
        {
            get { return _adaptee.IsModified; }
            set { _adaptee.IsModified = value; }
        }

        public object OriginalValue
        {
            get { return _adaptee.OriginalValue; }
            set { _adaptee.OriginalValue = value; }
        }

        public IDbComplexPropertyEntry ParentProperty => _parentProperty.Value;

        public IDbPropertyEntry<TEntity, TProperty> Cast<TEntity, TProperty>() where TEntity : class
        {
            return new DbPropertyEntryAdapter<TEntity, TProperty>(_adaptee.Cast<TEntity, TProperty>());
        }
    }
}