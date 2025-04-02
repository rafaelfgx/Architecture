namespace Architecture.Application;

public sealed record GetExampleHandler(IExampleRepository exampleRepository) : IHandler<GetExampleRequest, ExampleModel>
{
    public async Task<Result<ExampleModel>> HandleAsync(GetExampleRequest request)
    {
        var model = await exampleRepository.GetModelAsync(request.Id);

        return new Result<ExampleModel>(model is null ? NotFound : OK, model);
    }
}
