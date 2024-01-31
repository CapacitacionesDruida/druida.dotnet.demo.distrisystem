
using druida.dotnet.shared.logging.Interfaces;
using Serilog.Events;

namespace druida.dotnet.shared.logging.Loggers;

public class ConsoleLoggerConfiguration : ILoggerConfiguration
{
    public bool Enabled { get; set; } = false;
    public LogEventLevel MinimumLevel { get; set; }
}
