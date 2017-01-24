using System;
using System.Data.Entity.Validation;

namespace EntityFramework6.Contrib.Validation
{
    // TODO: implement this
    internal class DbEntityValidationResultAdapter : IDbEntityValidationResult
    {
        private readonly DbEntityValidationResult _adaptee;

        public DbEntityValidationResultAdapter(DbEntityValidationResult adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}