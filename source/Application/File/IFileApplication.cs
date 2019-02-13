using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public interface IFileApplication
    {
        Task<IEnumerable<FileBinary>> AddAsync(string directory, IEnumerable<FileBinary> files);

        Task<FileBinary> SelectAsync(string directory, Guid id);
    }
}
