namespace Architecture.Web;

[Route("api/users")]
public sealed class UserController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public IActionResult Add(AddUserRequest request) => Mediator.HandleAsync<AddUserRequest, long>(request).ApiResult();

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id) => Mediator.HandleAsync(new DeleteUserRequest(id)).ApiResult();

    [HttpGet("{id:long}")]
    public IActionResult Get(long id) => Mediator.HandleAsync<GetUserRequest, UserModel>(new(id)).ApiResult();

    [HttpGet("grid")]
    public IActionResult Grid([FromQuery] GridUserRequest request) => Mediator.HandleAsync<GridUserRequest, Grid<UserModel>>(request).ApiResult();

    [HttpPatch("{id:long}/inactivate")]
    public IActionResult Inactivate(long id) => Mediator.HandleAsync(new InactivateUserRequest(id)).ApiResult();

    [HttpGet]
    public IActionResult List() => Mediator.HandleAsync<ListUserRequest, IEnumerable<UserModel>>(new()).ApiResult();

    [HttpPut("{id:long}")]
    public IActionResult Update(long id, UpdateUserRequest request) => Mediator.HandleAsync(request with { Id = id }).ApiResult();
}
