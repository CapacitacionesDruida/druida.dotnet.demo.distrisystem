using druida.dotnet.shared.logging.Interfaces;
using Serilog;

namespace druida.dotnet.shared.logging.Abstractions;

public abstract class LoggerConfigurationExtensionsAbstract
{
    public LoggerConfiguration AddConsoleLogger(LoggerConfiguration loggerConfiguration, ILoggerConfiguration consoleLoggerConfiguration)
    {
        return consoleLoggerConfiguration.Enabled
            ? loggerConfiguration.WriteTo.Console(consoleLoggerConfiguration.MinimumLevel)
            : loggerConfiguration;
    }

    public abstract LoggerConfiguration AddAppLogger( LoggerConfiguration loggerConfiguration, ILoggerConfiguration appLoggerConfiguration);
}
