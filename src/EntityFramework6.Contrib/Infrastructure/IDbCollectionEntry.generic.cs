using System.Collections.Generic;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbCollectionEntry<TEntity, TElement> : IDbMemberEntry<TEntity, ICollection<TElement>>
        where TEntity : class
    {
    }
}