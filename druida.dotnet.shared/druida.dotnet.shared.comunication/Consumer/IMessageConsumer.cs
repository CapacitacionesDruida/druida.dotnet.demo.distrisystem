namespace druida.dotnet.shared.comunication.Consumer;

public interface IMessageConsumer
{
    Task StartAsync(CancellationToken cancelToken = default);
}

public interface IMessageConsumer<T> : IMessageConsumer
{
}