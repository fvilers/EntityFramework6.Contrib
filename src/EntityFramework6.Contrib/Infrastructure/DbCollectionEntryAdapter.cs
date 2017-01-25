using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbCollectionEntryAdapter : DbMemberEntryAdapter, IDbCollectionEntry
    {
        private readonly DbCollectionEntry _adaptee;

        public DbCollectionEntryAdapter(DbCollectionEntry adaptee)
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

        public IDbCollectionEntry<TEntity, TElement> Cast<TEntity, TElement>() where TEntity : class
        {
            return new DbCollectionEntryAdapter<TEntity, TElement>(_adaptee.Cast<TEntity, TElement>());
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