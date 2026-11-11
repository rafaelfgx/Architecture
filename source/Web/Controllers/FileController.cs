namespace Architecture.Web;

[Route("api/files")]
public sealed class FileController(IMediator mediator) : BaseController(mediator)
{
    [DisableRequestSizeLimit]
    [HttpPost]
    public IActionResult Add() => Mediator.HandleAsync<AddFileRequest, IEnumerable<BinaryFile>>(new(Request.Files())).ApiResult();

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id) => Mediator.HandleAsync<GetFileRequest, BinaryFile>(new(id)).ApiResult();
}
