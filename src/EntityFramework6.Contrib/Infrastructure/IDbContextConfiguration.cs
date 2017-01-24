namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbContextConfiguration
    {
        bool AutoDetectChangesEnabled { get; set; }
        bool EnsureTransactionsForFunctionsAndCommands { get; set; }
        bool LazyLoadingEnabled { get; set; }
        bool ProxyCreationEnabled { get; set; }
        bool UseDatabaseNullSemantics { get; set; }
        bool ValidateOnSaveEnabled { get; set; }
    }
}