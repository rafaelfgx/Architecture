using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class FileApplication : IFileApplication
    {
        public FileApplication(IFileDomain fileDomain)
        {
            FileDomain = fileDomain;
        }

        private IFileDomain FileDomain { get; }

        public Task<IEnumerable<FileBinary>> AddAsync(string directory, IEnumerable<FileBinary> files)
        {
            return FileDomain.AddAsync(directory, files);
        }

        public Task<FileBinary> SelectAsync(string directory, Guid id)
        {
            return FileDomain.SelectAsync(directory, id);
        }
    }
}
