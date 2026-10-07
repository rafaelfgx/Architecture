namespace Architecture.Database;

public sealed class UserRepository(Context context) : EFRepository<User>(context), IUserRepository
{
    public static Expression<Func<User, UserModel>> Model => entity => new UserModel(entity.Id, entity.Name, entity.Email);

    public Task<UserModel> GetModelAsync(long id) => Queryable.Where(entity => entity.Id == id).Select(Model).SingleOrDefaultAsync();

    public Task<Grid<UserModel>> GridAsync(GridParameters parameters) => Queryable.Select(Model).GridAsync(parameters);

    public async Task<IEnumerable<UserModel>> ListModelAsync() => await Queryable.Select(Model).ToListAsync();
}
