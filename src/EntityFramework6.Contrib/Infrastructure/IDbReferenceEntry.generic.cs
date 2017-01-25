namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbReferenceEntry<TEntity, TProperty> : IDbMemberEntry<TEntity, TProperty>
        where TEntity : class
    {
    }
}