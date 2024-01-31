namespace druida.dotnet.shared.comunication.Consumer.Manager;

public interface IConsumerManager<TMessage>
{
    void RestartExecution();
    void StopExecution();
    CancellationToken GetCancellationToken();
}