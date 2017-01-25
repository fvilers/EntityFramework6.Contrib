namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbComplexPropertyEntry<TEntity, TComplexProperty> : IDbPropertyEntry<TEntity, TComplexProperty>
        where TEntity : class
    {
    }
}