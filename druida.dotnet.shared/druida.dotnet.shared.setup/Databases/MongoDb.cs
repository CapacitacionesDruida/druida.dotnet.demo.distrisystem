using druida.dotnet.shared.databases.mongodb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace druida.dotnet.shared.setup.Databases;

public static class MongoDb
{
    public static IServiceCollection AddDistribtMongoDbConnectionProvider(this IServiceCollection serviceCollection,
        IConfiguration configuration, string name = "mongodb")
    {
        return serviceCollection
            .AddMongoDbConnectionProvider()
            .AddMongoDbDatabaseConfiguration(configuration)
            .AddMongoHealthCheck(name);
    }
}