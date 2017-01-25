using System;
using System.Data.Entity;

namespace EntityFramework6.Contrib
{
    // TODO: implement this
    public class DbContextTransactionAdapter : IDbContextTransaction
    {
        private readonly DbContextTransaction _adaptee;

        public DbContextTransactionAdapter(DbContextTransaction adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}