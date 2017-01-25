namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbPropertyEntry : IDbMemberEntry
    {
        bool IsModified { get; set; }
        object OriginalValue { get; set; }
        IDbComplexPropertyEntry ParentProperty { get; }

        IDbPropertyEntry<TEntity, TProperty> Cast<TEntity, TProperty>() where TEntity : class;
    }
}