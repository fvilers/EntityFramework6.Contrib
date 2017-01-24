using System;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbContextConfigurationAdapter : IDbContextConfiguration
    {
        private readonly DbContextConfiguration _adaptee;

        public DbContextConfigurationAdapter(DbContextConfiguration adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }

        public bool AutoDetectChangesEnabled
        {
            get { return _adaptee.AutoDetectChangesEnabled; }
            set { _adaptee.AutoDetectChangesEnabled = value; }
        }

        public bool LazyLoadingEnabled
        {
            get { return _adaptee.LazyLoadingEnabled; }
            set { _adaptee.LazyLoadingEnabled = value; }
        }

        public bool ProxyCreationEnabled
        {
            get { return _adaptee.ProxyCreationEnabled; }
            set { _adaptee.ProxyCreationEnabled = value; }
        }

        public bool UseDatabaseNullSemantics
        {
            get { return _adaptee.UseDatabaseNullSemantics; }
            set { _adaptee.UseDatabaseNullSemantics = value; }
        }

        public bool ValidateOnSaveEnabled
        {
            get { return _adaptee.ValidateOnSaveEnabled; }
            set { _adaptee.ValidateOnSaveEnabled = value; }
        }

    }
}