using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class GetExampleHandler(IExampleRepository exampleRepository) : IHandler<GetExampleRequest, ExampleModel>
{
    private readonly IExampleRepository _exampleRepository = exampleRepository;

    public async Task<Result<ExampleModel>> HandleAsync(GetExampleRequest request)
    {
        var model = await _exampleRepository.GetModelAsync(request.Id);

        return new Result<ExampleModel>(model is null ? NotFound : OK, model);
    }
}
