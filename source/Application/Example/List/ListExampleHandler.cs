using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record ListExampleHandler : IHandler<ListExampleRequest, IEnumerable<ExampleModel>>
{
    private readonly IExampleRepository _exampleRepository;

    public ListExampleHandler(IExampleRepository exampleRepository) => _exampleRepository = exampleRepository;

    public async Task<Result<IEnumerable<ExampleModel>>> HandleAsync(ListExampleRequest request)
    {
        var list = await _exampleRepository.ListModelAsync();

        return new Result<IEnumerable<ExampleModel>>(list is null ? NotFound : OK, list);
    }
}
