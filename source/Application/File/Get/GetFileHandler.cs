using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record GetFileHandler : IHandler<GetFileRequest, BinaryFile>
{
    public async Task<Result<BinaryFile>> HandleAsync(GetFileRequest request)
    {
        var file = await BinaryFile.ReadAsync("Files", request.Id);

        return new Result<BinaryFile>(file is null ? NotFound : OK, file);
    }
}
