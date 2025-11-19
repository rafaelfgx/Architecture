namespace Architecture.Application;

public sealed record ListExampleHandler(IExampleRepository exampleRepository) : IHandler<ListExampleRequest, IEnumerable<ExampleModel>>
{
    public async Task<Result<IEnumerable<ExampleModel>>> HandleAsync(ListExampleRequest request)
    {
        var list = await exampleRepository.ListModelAsync();

        return new Result<IEnumerable<ExampleModel>>(list is null ? NotFound : OK, list);
    }
}
