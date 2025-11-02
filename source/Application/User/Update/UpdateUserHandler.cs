namespace Architecture.Application;

public sealed record UpdateUserHandler
(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
)
: IHandler<UpdateUserRequest>
{
    public async Task<Result> HandleAsync(UpdateUserRequest request)
    {
        var user = await userRepository.GetAsync(request.Id);

        if (user is null) return new Result(NotFound);

        user.UpdateName(request.Name);

        user.UpdateEmail(request.Email);

        await userRepository.UpdateAsync(user);

        await unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
