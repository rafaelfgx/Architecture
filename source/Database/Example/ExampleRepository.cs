namespace Architecture.Database;

public sealed class ExampleRepository : EFRepository<Example>, IExampleRepository
{
    public ExampleRepository(Context context) : base(context) { }

    public static Expression<Func<Example, ExampleModel>> Model => entity => new ExampleModel { Id = entity.Id, Name = entity.Name };

    public Task<ExampleModel> GetModelAsync(long id) => Queryable.Where(entity => entity.Id == id).Select(Model).SingleOrDefaultAsync();

    public Task<Grid<ExampleModel>> GridAsync(GridParameters parameters) => Queryable.Select(Model).GridAsync(parameters);

    public async Task<IEnumerable<ExampleModel>> ListModelAsync() => await Queryable.Select(Model).ToListAsync();
}
