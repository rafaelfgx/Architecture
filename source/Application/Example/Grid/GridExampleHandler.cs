using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class GridExampleHandler(IExampleRepository exampleRepository) : IHandler<GridExampleRequest, Grid<ExampleModel>>
{
    private readonly IExampleRepository _exampleRepository = exampleRepository;

    public async Task<Result<Grid<ExampleModel>>> HandleAsync(GridExampleRequest request)
    {
        var grid = await _exampleRepository.GridAsync(request);

        return new Result<Grid<ExampleModel>>(grid is null ? NotFound : OK, grid);
    }
}
