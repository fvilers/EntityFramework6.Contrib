using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbCollectionEntry : IDbMemberEntry
    {
        bool IsLoaded { get; set; }

        IDbCollectionEntry<TEntity, TElement> Cast<TEntity, TElement>() where TEntity : class;
        void Load();
        Task LoadAsync();
        Task LoadAsync(CancellationToken cancellationToken);
    }
}