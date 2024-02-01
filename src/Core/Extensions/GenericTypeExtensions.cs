using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class GenericTypeExtensions
    {
        /// <summary>
        /// Get the name of the generic type of the object
        /// </summary>
        /// <param name="object">The generic object need to get name from it</param>
        /// <returns>The name of the generic type</returns>
        public static string GetGenericTypeName(this object @object)
        {
            var type = @object.GetType();

            // Check if the type is not generic
            if (!type.IsGenericType)
                return type.Name;

            // Get the names of the generic arguments and join them with commas
            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());

            return $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
    }
}
