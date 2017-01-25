namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbPropertyEntry<TEntity, TProperty> : IDbMemberEntry<TEntity, TProperty>
        where TEntity : class
    {
    }
}