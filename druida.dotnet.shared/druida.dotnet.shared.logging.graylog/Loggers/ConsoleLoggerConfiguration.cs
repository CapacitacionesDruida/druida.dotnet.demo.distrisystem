using druida.dotnet.shared.logging.graylog.Interfaces;
using Serilog.Events;

namespace druida.dotnet.shared.logging.graylog.Loggers;

public class ConsoleLoggerConfiguration: ILoggerConfiguration
{
    public bool Enabled { get; set; } = false;
    public LogEventLevel MinimumLevel { get; set; }
}
