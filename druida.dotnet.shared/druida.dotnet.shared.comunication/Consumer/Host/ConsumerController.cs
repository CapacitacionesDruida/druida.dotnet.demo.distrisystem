using druida.dotnet.shared.comunication.Consumer.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace druida.dotnet.shared.comunication.Consumer.Host;

public class ConsumerController<TMessage> : Controller
{
    private readonly IConsumerManager<TMessage> _consumerManager;

    public ConsumerController(IConsumerManager<TMessage> consumerManager)
    {
        _consumerManager = consumerManager;
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route("start")]
    public virtual IActionResult Start()
    {
        _consumerManager.RestartExecution();
        return Ok();
    }
}