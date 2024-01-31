using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using druida.dotnet.shared.eventsourcing;

namespace druida.dotnet.shared.setup.Services;

public static class EventSourcing
{
    public static void AddEventSourcing(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMongoEventSourcing(configuration);
    }
}
