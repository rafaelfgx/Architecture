using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class FilesController : ControllerBase
    {
        public FilesController(IHostingEnvironment environment, IFileApplication fileApplication)
        {
            Directory = Path.Combine(environment.ContentRootPath, "Files");
            FileApplication = fileApplication;
        }

        private string Directory { get; }

        private IFileApplication FileApplication { get; }

        [DisableRequestSizeLimit]
        [HttpPost]
        public Task<IEnumerable<FileBinary>> AddAsync()
        {
            return FileApplication.AddAsync(Directory, Request.Files());
        }

        [HttpGet("{id}")]
        public IActionResult SelectAsync(Guid id)
        {
            var fileBinary = FileApplication.SelectAsync(Directory, id).Result;

            new FileExtensionContentTypeProvider().TryGetContentType(fileBinary.Name, out var contentType);

            return File(fileBinary.Bytes, contentType, fileBinary.Name);
        }
    }
}
