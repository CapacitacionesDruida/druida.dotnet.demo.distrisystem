using Serilog;

namespace druida.dotnet.shared.logging.appinsights.Loggers;

public static class LoggerConfigurationExtensions
{

    public static LoggerConfiguration AddConsoleLogger(this LoggerConfiguration loggerConfiguration, ConsoleLoggerConfiguration consoleLoggerConfiguration)
    {
        return consoleLoggerConfiguration.Enabled
            ? loggerConfiguration.WriteTo.Console(consoleLoggerConfiguration.MinimumLevel)
            : loggerConfiguration;
    }

    public static LoggerConfiguration AddServiceLogger(this LoggerConfiguration loggerConfiguration, AppInsightsLoggerConfiguration appInsightsLoggerConfiguration)
    {
         return appInsightsLoggerConfiguration.Enabled
             ? loggerConfiguration.WriteTo.ApplicationInsights(restrictedToMinimumLevel: appInsightsLoggerConfiguration.MinimumLevel, telemetryConverter: TelemetryConverter.Traces)
             : loggerConfiguration;
    }
}
