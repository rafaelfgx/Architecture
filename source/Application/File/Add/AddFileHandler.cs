using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record AddFileHandler : IHandler<AddFileRequest, IEnumerable<BinaryFile>>
{
    public async Task<Result<IEnumerable<BinaryFile>>> HandleAsync(AddFileRequest request)
    {
        var files = await request.Files.SaveAsync("Files");

        return new Result<IEnumerable<BinaryFile>>(Created, files);
    }
}
