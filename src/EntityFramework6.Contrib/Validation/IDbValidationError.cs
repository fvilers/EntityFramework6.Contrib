namespace EntityFramework6.Contrib.Validation
{
    public interface IDbValidationError
    {
        string ErrorMessage { get; }
        string PropertyName { get; }
    }
}