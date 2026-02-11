namespace Architecture.Application;

public sealed class DeleteUserHandler
(
    IAuthRepository authRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
)
: IHandler<DeleteUserRequest>
{
    public async Task<Result> HandleAsync(DeleteUserRequest request)
    {
        await authRepository.DeleteByUserIdAsync(request.Id);

        await userRepository.DeleteAsync(request.Id);

        await unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
