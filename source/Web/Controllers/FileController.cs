using Architecture.Application;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web;

[ApiController]
[Route("files")]
public sealed class FileController : ControllerBase
{
    private readonly string _directory;
    private readonly IFileService _fileService;

    public FileController
    (
        IFileService fileService,
        IHostEnvironment environment
    )
    {
        _fileService = fileService;
        _directory = Path.Combine(environment.ContentRootPath, "Files");
    }

    [DisableRequestSizeLimit]
    [HttpPost]
    public Task<IEnumerable<BinaryFile>> AddAsync() => _fileService.AddAsync(_directory, Request.Files());

    [HttpGet("{id}")]
    public IActionResult Get(Guid id) => _fileService.GetAsync(_directory, id).FileResult();
}
