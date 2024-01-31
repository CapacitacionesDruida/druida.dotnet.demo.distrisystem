namespace druida.dotnet.shared.comunication.Messages;

public record Metadata
{
    public string CorrelationId { get; }
    public DateTime CreatedUtc { get; }

    public Metadata(string correlationId, DateTime createdUtc)
    {
        CorrelationId = correlationId;
        CreatedUtc = createdUtc;
    }
}