using lib;
using OperationService.Event;
using System.Collections.Generic;
using System.Reflection;

namespace OperationService.Extensions
{
    public static class SocketEventExtensions
    {
        internal static HashSet<Type> ScanInjectingClientEventHandlers(
            this WebApplicationBuilder builder,
            Assembly assemblyReference,
            ServiceLifetime? lifetime = ServiceLifetime.Singleton)
        {
            HashSet<Type> clientEventhandlers = new HashSet<Type>();
            Type[] types = assemblyReference.GetTypes();
            foreach (Type type in types)
            {
                if (type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEventHandler<>))
                {
                    if (lifetime.Equals(ServiceLifetime.Singleton))
                    {
                        builder.Services.AddSingleton(type);
                    }
                    else if (lifetime.Equals(ServiceLifetime.Scoped))
                    {
                        builder.Services.AddScoped(type);
                    }

                    clientEventhandlers.Add(type);
                }
            }

            return clientEventhandlers;
        }
    }
}
