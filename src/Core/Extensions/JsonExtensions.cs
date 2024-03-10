using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions().Configure();

        public static T FromJson<T>(this string value) =>
            value is not null ? Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value) : default;

        public static string ToJson<T>(this T value) =>
            Newtonsoft.Json.JsonConvert.SerializeObject(value);
        //{
        //    var json = JsonSerializer.Serialize(value, JsonOptions);
        //    return value != null ? JsonSerializer.Serialize(value, JsonOptions) : default;
        //}

        public static JsonSerializerOptions Configure(this JsonSerializerOptions jsonSettings)
        {
            jsonSettings.WriteIndented = false;
            jsonSettings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            jsonSettings.ReadCommentHandling = JsonCommentHandling.Skip;
            jsonSettings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            jsonSettings.TypeInfoResolver = new PrivateConstructorContractResolver();
            jsonSettings.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            return jsonSettings;
        }
    }

    internal sealed class PrivateConstructorContractResolver : DefaultJsonTypeInfoResolver
    {
        /// <summary>
        /// Gets the JSON type information for the specified type, with support for creating objects with private constructors.
        /// </summary>
        /// <param name="type">The type to get the JSON type information for.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use for serialization.</param>
        /// <returns>The JSON type information for the specified type.</returns>
        public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            var jsonTypeInfo = base.GetTypeInfo(type, options);

            // Check if the type is an object, has no public constructor, and CreateObject is not already set
            if (jsonTypeInfo.Kind == JsonTypeInfoKind.Object
                && jsonTypeInfo.CreateObject is null
                && jsonTypeInfo.Type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length == 0)
            {
                // Set CreateObject to a lambda expression that creates an instance using a private constructor
                jsonTypeInfo.CreateObject = () => Activator.CreateInstance(jsonTypeInfo.Type, true);
            }

            return jsonTypeInfo;
        }
    }
}
