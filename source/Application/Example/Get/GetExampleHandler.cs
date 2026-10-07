namespace Architecture.Application;

public sealed class GetExampleHandler(IExampleRepository exampleRepository) : IHandler<GetExampleRequest, ExampleModel>
{
    public async Task<Result<ExampleModel>> HandleAsync(GetExampleRequest request)
    {
        var model = await exampleRepository.GetModelAsync(request.Id);

        return new(model is null ? NotFound : OK, model);
    }
}
