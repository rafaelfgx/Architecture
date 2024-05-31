namespace Architecture.Database;

public sealed class AuthRepository : EFRepository<Auth>, IAuthRepository
{
    public AuthRepository(Context context) : base(context) { }

    public Task DeleteByUserIdAsync(long userId) => DeleteAsync(entity => entity.User.Id == userId);

    public Task<Auth> GetByLoginAsync(string login) => Queryable.SingleOrDefaultAsync(entity => entity.Login == login);
}
