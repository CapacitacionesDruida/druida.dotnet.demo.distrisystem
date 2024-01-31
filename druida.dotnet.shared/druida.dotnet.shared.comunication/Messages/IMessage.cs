namespace druida.dotnet.shared.comunication.Messages;

public interface IMessage
{
    /// <summary>
    /// Must be unique;
    /// </summary>
    public string MessageIdentifier { get; }
    /// <summary>
    /// Name for the message, useful in logs/databases, etc
    /// </summary>
    public string Name { get; }
}