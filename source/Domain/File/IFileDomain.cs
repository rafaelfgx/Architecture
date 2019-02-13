using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Domain
{
    public interface IFileDomain
    {
        Task<IEnumerable<FileBinary>> AddAsync(string directory, IEnumerable<FileBinary> files);

        Task<FileBinary> SelectAsync(string directory, Guid id);
    }
}
