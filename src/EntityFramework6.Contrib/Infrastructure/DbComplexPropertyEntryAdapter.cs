using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    // TODO: implement this
    internal class DbComplexPropertyEntryAdapter : IDbComplexPropertyEntry
    {
        private readonly DbComplexPropertyEntry _adapter;

        public DbComplexPropertyEntryAdapter(DbComplexPropertyEntry adapter)
        {
            if (adapter == null) throw new ArgumentNullException(nameof(adapter));
            _adapter = adapter;
        }
    }
}