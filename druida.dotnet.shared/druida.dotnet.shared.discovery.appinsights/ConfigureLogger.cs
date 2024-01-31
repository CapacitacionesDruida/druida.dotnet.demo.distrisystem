using druida.dotnet.shared.discovery.consul;
using druida.dotnet.shared.logging.appinsights.Loggers;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace druida.dotnet.shared.logging.appinsights;

public static class ConfigureLogger
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder builder, IServiceDiscovery discovery)
        => builder.UseSerilog((context, loggerConfiguration)
            => ConfigureSerilogLogger(loggerConfiguration, context.Configuration, discovery));

    private static LoggerConfiguration ConfigureSerilogLogger(LoggerConfiguration loggerConfiguration, IConfiguration configuration, IServiceDiscovery discovery)
    {
        var appInsightslogLogger = new AppInsightsLoggerConfiguration();
        configuration.GetSection("Logging:AppInsights").Bind(appInsightslogLogger);

        ConsoleLoggerConfiguration consoleLogger = new ConsoleLoggerConfiguration();
        configuration.GetSection("Logging:Console").Bind(consoleLogger);

        return loggerConfiguration
                .AddConsoleLogger(consoleLogger)
                .AddServiceLogger(appInsightslogLogger);
    }
}