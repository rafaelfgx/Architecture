using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class InactivateUserHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository
    ) : IHandler<InactivateUserRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result> HandleAsync(InactivateUserRequest request)
    {
        var user = new User(request.Id);

        user.Inactivate();

        await _userRepository.UpdatePartialAsync(new { user.Id, user.Status });

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
