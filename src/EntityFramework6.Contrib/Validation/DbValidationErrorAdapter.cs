using System;
using System.Data.Entity.Validation;

namespace EntityFramework6.Contrib.Validation
{
    internal class DbValidationErrorAdapter : IDbValidationError
    {
        private readonly DbValidationError _adaptee;

        public DbValidationErrorAdapter(DbValidationError adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }

        public string ErrorMessage => _adaptee.ErrorMessage;
        public string PropertyName => _adaptee.PropertyName;
    }
}