namespace Architecture.Web;

[ApiController]
[Route("api/auths")]
public sealed class AuthController : BaseController
{
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Auth(AuthRequest request) => Mediator.HandleAsync<AuthRequest, AuthResponse>(request).ApiResult();
}
