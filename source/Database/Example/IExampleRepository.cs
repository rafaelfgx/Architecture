namespace Architecture.Database;

public interface IExampleRepository : IRepository<Example>
{
    Task<ExampleModel> GetModelAsync(long id);

    Task<Grid<ExampleModel>> GridAsync(GridParameters parameters);

    Task<IEnumerable<ExampleModel>> ListModelAsync();
}
