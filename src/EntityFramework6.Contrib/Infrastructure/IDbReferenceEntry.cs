using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbReferenceEntry : IDbMemberEntry
    {
        bool IsLoaded { get; set; }

        IDbReferenceEntry<TEntity, TProperty> Cast<TEntity, TProperty>() where TEntity : class;
        void Load();
        Task LoadAsync();
        Task LoadAsync(CancellationToken cancellationToken);
        IQueryable Query();
    }
}