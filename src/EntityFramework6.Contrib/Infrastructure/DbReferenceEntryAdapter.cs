using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbReferenceEntryAdapter : DbMemberEntryAdapter, IDbReferenceEntry
    {
        private readonly DbReferenceEntry _adaptee;

        public DbReferenceEntryAdapter(DbReferenceEntry adaptee)
            : base(adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }

        public bool IsLoaded
        {
            get { return _adaptee.IsLoaded; }
            set { _adaptee.IsLoaded = value; }
        }

        public IDbReferenceEntry<TEntity, TProperty> Cast<TEntity, TProperty>() where TEntity : class
        {
            return new DbReferenceEntryAdapter<TEntity, TProperty>(_adaptee.Cast<TEntity, TProperty>());
        }

        public void Load()
        {
            _adaptee.Load();
        }

        public Task LoadAsync()
        {
            return _adaptee.LoadAsync();
        }

        public Task LoadAsync(CancellationToken cancellationToken)
        {
            return _adaptee.LoadAsync(cancellationToken);
        }

        public IQueryable Query()
        {
            return _adaptee.Query();
        }
    }
}