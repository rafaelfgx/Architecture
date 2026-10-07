namespace Architecture.Web;

[Route("api/auth")]
public sealed class AuthController(IMediator mediator) : BaseController(mediator)
{
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Auth(AuthRequest request) => Mediator.HandleAsync<AuthRequest, AuthResponse>(request).ApiResult();
}
