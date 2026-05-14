namespace Architecture.Web;

[ApiController]
[Route("api/examples")]
public sealed class ExampleController : BaseController
{
    [HttpPost]
    public IActionResult Add(AddExampleRequest request) => Mediator.HandleAsync<AddExampleRequest, long>(request).ApiResult();

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id) => Mediator.HandleAsync(new DeleteExampleRequest(id)).ApiResult();

    [HttpGet("{id:long}")]
    public IActionResult Get(long id) => Mediator.HandleAsync<GetExampleRequest, ExampleModel>(new GetExampleRequest(id)).ApiResult();

    [HttpGet("grid")]
    public IActionResult Grid([FromQuery] GridExampleRequest request) => Mediator.HandleAsync<GridExampleRequest, Grid<ExampleModel>>(request).ApiResult();

    [HttpGet]
    public IActionResult List() => Mediator.HandleAsync<ListExampleRequest, IEnumerable<ExampleModel>>(new ListExampleRequest()).ApiResult();

    [HttpPut("{id:long}")]
    public IActionResult Update(long id, UpdateExampleRequest request) => Mediator.HandleAsync(request with { Id = id }).ApiResult();
}
