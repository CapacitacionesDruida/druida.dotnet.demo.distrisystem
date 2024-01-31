﻿using druida.dotnet.shared.discovery.consul;
using druida.dotnet.shared.logging.graylog.Loggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace druida.dotnet.shared.logging.graylog;

public static class ConfigureLogger
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder builder, IServiceDiscovery discovery)
        => builder.UseSerilog((context, loggerConfiguration)
            => ConfigureSerilogLogger(loggerConfiguration, context.Configuration, discovery));

    private static LoggerConfiguration ConfigureSerilogLogger(LoggerConfiguration loggerConfiguration, IConfiguration configuration, IServiceDiscovery discovery)
    {
        var graylogLogger = new GraylogLoggerConfiguration();
        configuration.GetSection("Logging:Graylog").Bind(graylogLogger);
        DiscoveryData discoveryData = discovery.GetDiscoveryData(DiscoveryServices.Graylog).Result;
        graylogLogger.Host = discoveryData.Server;
        graylogLogger.Port = discoveryData.Port;
        ConsoleLoggerConfiguration consoleLogger = new ConsoleLoggerConfiguration();
        configuration.GetSection("Logging:Console").Bind(consoleLogger);

        return loggerConfiguration
                .AddConsoleLogger(consoleLogger)
                .AddServiceLogger(graylogLogger);
    }
}