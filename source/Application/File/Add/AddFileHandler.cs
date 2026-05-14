namespace Architecture.Application;

public sealed class AddFileHandler : IHandler<AddFileRequest, IEnumerable<BinaryFile>>
{
    public async Task<Result<IEnumerable<BinaryFile>>> HandleAsync(AddFileRequest request)
    {
        var files = await request.Files.SaveAsync("Files");

        return new Result<IEnumerable<BinaryFile>>(Created, files);
    }
}
