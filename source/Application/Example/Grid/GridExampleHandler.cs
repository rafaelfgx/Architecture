namespace Architecture.Application;

public sealed class GridExampleHandler(IExampleRepository exampleRepository) : IHandler<GridExampleRequest, Grid<ExampleModel>>
{
    public async Task<Result<Grid<ExampleModel>>> HandleAsync(GridExampleRequest request)
    {
        var grid = await exampleRepository.GridAsync(request);

        return new(grid is null ? NotFound : OK, grid);
    }
}
