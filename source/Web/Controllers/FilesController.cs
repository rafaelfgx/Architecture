using Architecture.Application;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web;

[ApiController]
[Route("files")]
public sealed class FilesController : ControllerBase
{
    private readonly string _directory;
    private readonly IFileService _fileService;

    public FilesController
    (
        IFileService fileService,
        IHostEnvironment environment
    )
    {
        _directory = Path.Combine(environment.ContentRootPath, "Files");
        _fileService = fileService;
    }

    [DisableRequestSizeLimit]
    [HttpPost]
    public Task<IEnumerable<BinaryFile>> AddAsync() => _fileService.AddAsync(_directory, Request.Files());

    [HttpGet("{id}")]
    public IActionResult Get(Guid id) => _fileService.GetAsync(_directory, id).FileResult();
}
