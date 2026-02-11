namespace Architecture.Application;

public sealed class GetUserHandler(IUserRepository userRepository) : IHandler<GetUserRequest, UserModel>
{
    public async Task<Result<UserModel>> HandleAsync(GetUserRequest request)
    {
        var user = await userRepository.GetModelAsync(request.Id);

        return new Result<UserModel>(user is null ? NotFound : OK, user);
    }
}
