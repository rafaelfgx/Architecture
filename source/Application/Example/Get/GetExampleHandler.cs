using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record GetExampleHandler : IHandler<GetExampleRequest, ExampleModel>
{
    private readonly IExampleRepository _exampleRepository;

    public GetExampleHandler(IExampleRepository exampleRepository) => _exampleRepository = exampleRepository;

    public async Task<Result<ExampleModel>> HandleAsync(GetExampleRequest request)
    {
        var model = await _exampleRepository.GetModelAsync(request.Id);

        return new Result<ExampleModel>(model is null ? NotFound : OK, model);
    }
}
