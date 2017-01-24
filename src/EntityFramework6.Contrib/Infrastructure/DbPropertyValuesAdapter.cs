using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace EntityFramework6.Contrib.Infrastructure
{
    internal class DbPropertyValuesAdapter : IDbPropertyValues
    {
        private readonly DbPropertyValues _adaptee;

        public DbPropertyValuesAdapter(DbPropertyValues adaptee)
        {
            if (adaptee == null) throw new ArgumentNullException(nameof(adaptee));
            _adaptee = adaptee;
        }

        public object this[string propertyName]
        {
            get { return _adaptee[propertyName]; }
            set { _adaptee[propertyName] = value; }
        }

        public IEnumerable<string> PropertyNames => _adaptee.PropertyNames;

        public IDbPropertyValues Clone()
        {
            return new DbPropertyValuesAdapter(_adaptee.Clone());
        }

        public TValue GetValue<TValue>(string propertyName)
        {
            return _adaptee.GetValue<TValue>(propertyName);
        }

        public void SetValues(IDbPropertyValues propertyValues)
        {
            var adapter = propertyValues as DbPropertyValuesAdapter;

            if (adapter == null)
            {
                throw new NotSupportedException();
            }

            _adaptee.SetValues(adapter._adaptee);
        }

        public void SetValues(object obj)
        {
            _adaptee.SetValues(obj);
        }

        public object ToObject()
        {
            return _adaptee.ToObject();
        }
    }
}