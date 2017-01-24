using System.Collections.Generic;

namespace EntityFramework6.Contrib.Infrastructure
{
    public interface IDbPropertyValues
    {
        object this[string propertyName] { get; set; }
        IEnumerable<string> PropertyNames { get; }
        IDbPropertyValues Clone();
        TValue GetValue<TValue>(string propertyName);
        void SetValues(IDbPropertyValues propertyValues);
        void SetValues(object obj);
        object ToObject();
    }
}