namespace Architecture.Web;

[ApiController]
[Route("api/users")]
public sealed class UserController : BaseController
{
    [HttpPost]
    public IActionResult Add(AddUserRequest request) => Mediator.HandleAsync<AddUserRequest, long>(request).ApiResult();

    [HttpDelete("{id}")]
    public IActionResult Delete(long id) => Mediator.HandleAsync(new DeleteUserRequest(id)).ApiResult();

    [HttpGet("{id}")]
    public IActionResult Get(long id) => Mediator.HandleAsync<GetUserRequest, UserModel>(new GetUserRequest(id)).ApiResult();

    [HttpGet("grid")]
    public IActionResult Grid([FromQuery] GridUserRequest request) => Mediator.HandleAsync<GridUserRequest, Grid<UserModel>>(request).ApiResult();

    [HttpPatch("{id}/inactivate")]
    public IActionResult Inactivate(long id) => Mediator.HandleAsync(new InactivateUserRequest(id)).ApiResult();

    [HttpGet]
    public IActionResult List() => Mediator.HandleAsync<ListUserRequest, IEnumerable<UserModel>>(new ListUserRequest()).ApiResult();

    [HttpPut("{id}")]
    public IActionResult Update(long id, UpdateUserRequest request)
    {
        request.Id = id;

        return Mediator.HandleAsync(request).ApiResult();
    }
}
