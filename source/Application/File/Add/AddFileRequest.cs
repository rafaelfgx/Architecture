namespace Architecture.Application;

public sealed record AddFileRequest(IEnumerable<BinaryFile> Files);
