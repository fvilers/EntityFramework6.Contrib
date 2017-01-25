using System;
using System.Data.Entity;

namespace EntityFramework6.Contrib
{
    // TODO: implement this
    public class DbModelBuilderAdapter : IDbModelBuilder
    {
        public DbModelBuilder Adaptee { get; }

        public DbModelBuilderAdapter(DbModelBuilder adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            Adaptee = adaptee;
        }
    }
}