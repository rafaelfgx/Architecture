using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class ListUserHandler(IUserRepository userRepository) :
    IHandler<ListUserRequest, IEnumerable<UserModel>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<IEnumerable<UserModel>>> HandleAsync(ListUserRequest request)
    {
        var users = await _userRepository.ListModelAsync();

        return new Result<IEnumerable<UserModel>>(users is null ? NotFound : OK, users);
    }
}
