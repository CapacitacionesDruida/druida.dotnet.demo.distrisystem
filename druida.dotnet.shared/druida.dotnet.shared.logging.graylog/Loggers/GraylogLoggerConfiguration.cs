using druida.dotnet.shared.logging.graylog.Interfaces;
using Serilog.Events;

namespace druida.dotnet.shared.logging.graylog.Loggers;

public class GraylogLoggerConfiguration : ILoggerConfiguration
{
    public bool Enabled { get; set; } = false;
    public LogEventLevel MinimumLevel { get; set; }
    public string Host { get; set; } = "";
    public int Port { get; set; }
}
