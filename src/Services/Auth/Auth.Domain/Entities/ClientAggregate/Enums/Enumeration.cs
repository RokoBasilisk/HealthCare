using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.ClientAggregate.Enums
{
    public abstract class Enumeration : IComparable
    {
        public string Value { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string value) => (Id, Value) = (id, value);

        public override string? ToString()
            => Value;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object? obj) => Id.CompareTo(((Enumeration)obj).Id);
    }
}
