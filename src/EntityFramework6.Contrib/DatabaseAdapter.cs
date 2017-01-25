using System;
using System.Data.Entity;

namespace EntityFramework6.Contrib
{
    // TODO: implement this
    public class DatabaseAdapter : IDatabase
    {
        private readonly Database _adaptee;

        public DatabaseAdapter(Database adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }
    }
}