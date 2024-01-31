using Microsoft.Extensions.DependencyInjection;

namespace druida.dotnet.shared.serialization
{
    public static class SerializationDependencyInjection
    {
        public static void AddSerializer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISerializer, Serializer>();
        }
    }
}
