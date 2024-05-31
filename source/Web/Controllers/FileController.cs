namespace Architecture.Web;

[ApiController]
[Route("api/files")]
public sealed class FileController : BaseController
{
    [DisableRequestSizeLimit]
    [HttpPost]
    public IActionResult Add() => Mediator.HandleAsync<AddFileRequest, IEnumerable<BinaryFile>>(new AddFileRequest(Request.Files())).ApiResult();

    [HttpGet("{id}")]
    public IActionResult Get(Guid id) => Mediator.HandleAsync<GetFileRequest, BinaryFile>(new GetFileRequest(id)).ApiResult();
}
