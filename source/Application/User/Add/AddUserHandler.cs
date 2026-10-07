namespace Architecture.Application;

public sealed class AddUserHandler(IAuthRepository authRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IHashService hashService) : IHandler<AddUserRequest, long>
{
    public async Task<Result<long>> HandleAsync(AddUserRequest request)
    {
        var user = new User(request.Name, request.Email);

        var auth = new Auth(request.Login, request.Password, user);

        auth.UpdatePassword(hashService.Create(auth.Password, auth.Salt.ToString()));

        await userRepository.AddAsync(user);

        await authRepository.AddAsync(auth);

        await unitOfWork.SaveChangesAsync();

        return new(Created, user.Id);
    }
}
