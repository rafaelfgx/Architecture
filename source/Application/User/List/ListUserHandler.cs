namespace Architecture.Application;

public sealed class ListUserHandler(IUserRepository userRepository) : IHandler<ListUserRequest, IEnumerable<UserModel>>
{
    public async Task<Result<IEnumerable<UserModel>>> HandleAsync(ListUserRequest request)
    {
        var users = await userRepository.ListModelAsync();

        return new(users is null ? NotFound : OK, users);
    }
}
