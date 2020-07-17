using Architecture.Application;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Architecture.Web
{
    [ApiController]
    [Route("files")]
    public class FileController : ControllerBase
    {
        private readonly IContentTypeProvider _contentTypeProvider;
        private readonly string _directory;
        private readonly IFileService _fileService;

        public FileController
        (
            IContentTypeProvider contentTypeProvider,
            IFileService fileService,
            IHostEnvironment environment
        )
        {
            _contentTypeProvider = contentTypeProvider;
            _directory = Path.Combine(environment.ContentRootPath, "Files");
            _fileService = fileService;
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        public Task<IEnumerable<BinaryFile>> AddAsync()
        {
            return _fileService.AddAsync(_directory, Request.Files());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var file = await _fileService.GetAsync(_directory, id);

            _contentTypeProvider.TryGetContentType(file.ContentType, out var contentType);

            return File(file.Bytes, contentType, file.Name);
        }
    }
}
