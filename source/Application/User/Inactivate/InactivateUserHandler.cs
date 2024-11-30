namespace Architecture.Application;

public sealed record InactivateUserHandler
(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
)
: IHandler<InactivateUserRequest>
{
    public async Task<Result> HandleAsync(InactivateUserRequest request)
    {
        var user = new User(request.Id);

        user.Inactivate();

        await userRepository.UpdatePartialAsync(new { user.Id, user.Status });

        await unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
