using druida.dotnet.shared.comunication.Messages;

namespace druida.dotnet.shared.comunication.Consumer.Handler;

public interface IMessageHandler
{
}

public interface IMessageHandler<in TMessage> : IMessageHandler
{
    Task Handle(TMessage message, CancellationToken cancelToken = default(CancellationToken));
}

public interface IIntegrationMessageHandler : IMessageHandler
{
}

public interface IIntegrationMessageHandler<TMessage> 
    : IMessageHandler<IntegrationMessage<TMessage>>, IIntegrationMessageHandler
{
}

public interface IDomainMessageHandler : IMessageHandler
{
}

public interface IDomainMessageHandler<TMessage> 
    : IMessageHandler<DomainMessage<TMessage>>, IDomainMessageHandler
{
}