namespace Architecture.Web;

[ApiController]
public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected IMediator Mediator { get; } = mediator;
}
