using System;
using System.Data.Entity;

namespace EntityFramework6.Contrib
{
    // TODO: implement this
    public class DbSetAdapter : IDbSet
    {
        private readonly DbSet _adaptee;

        public DbSetAdapter(DbSet adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}