using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Domain
{
    public sealed class FileDomain : IFileDomain
    {
        public Task<IEnumerable<FileBinary>> AddAsync(string directory, IEnumerable<FileBinary> files)
        {
            Directory.CreateDirectory(directory);

            foreach (var file in files)
            {
                var fileName = string.Concat(file.Id, Path.GetExtension(file.Name));

                var filePath = Path.Combine(directory, fileName);

                File.WriteAllBytes(filePath, file.Bytes);

                file.Bytes = null;
            }

            return Task.FromResult(files);
        }

        public Task<FileBinary> SelectAsync(string directory, Guid id)
        {
            var fileInfo = new DirectoryInfo(directory).GetFiles("*" + id + "*.*").SingleOrDefault();

            if (fileInfo == null)
            {
                return null;
            }

            var fileBinary = new FileBinary
            {
                Bytes = File.ReadAllBytes(fileInfo.FullName),
                Name = fileInfo.Name,
                Length = fileInfo.Length
            };

            return Task.FromResult(fileBinary);
        }
    }
}
