using druida.dotnet.shared.databases.sqlserver;
using druida.dotnet.shared.discovery.consul;
using druida.dotnet.shared.secrets.hashicorpvault;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace druida.dotnet.shared.setup.Databases;

public static class SQLServer
{
    public static IServiceCollection AddSQLSerer<T>(this IServiceCollection serviceCollection, string databaseName)
        where T : DbContext
    {
        return serviceCollection
            .AddSQLServerDbContext<T>(serviceProvider => GetConnectionString(serviceProvider, databaseName))
            .AddSQLServerHealthCheck(serviceProvider => GetConnectionString(serviceProvider, databaseName));
    }

    private static async Task<string> GetConnectionString(IServiceProvider serviceProvider, string databaseName)
    {
        ISecretManager secretManager = serviceProvider.GetRequiredService<ISecretManager>();
        IServiceDiscovery serviceDiscovery = serviceProvider.GetRequiredService<IServiceDiscovery>();

        DiscoveryData sqlServerData = await serviceDiscovery.GetDiscoveryData(DiscoveryServices.SQLServer);
        SQLServerCredentials credentials = await secretManager.Get<SQLServerCredentials>("sqlserver");

        return $"Data Source={sqlServerData.Server},{sqlServerData.Port};Initial Catalog={databaseName};Persist Security Info=False;User ID={credentials.username};Password={credentials.password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

    private record SQLServerCredentials
    {
        public string username { get; init; } = null!;
        public string password { get; init; } = null!;
    }
}
