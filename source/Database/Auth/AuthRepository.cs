namespace Architecture.Database;

public sealed class AuthRepository(Context context) : EFRepository<Auth>(context), IAuthRepository
{
    public Task DeleteByUserIdAsync(long userId) => DeleteAsync(entity => entity.User.Id == userId);

    public Task<Auth> GetByLoginAsync(string login) => Queryable.SingleOrDefaultAsync(entity => entity.Login == login);
}
