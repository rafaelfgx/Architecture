using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class DeleteUserHandler(
    IUnitOfWork unitOfWork,
    IAuthRepository authRepository,
    IUserRepository userRepository
    ) : IHandler<DeleteUserRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAuthRepository _authRepository = authRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result> HandleAsync(DeleteUserRequest request)
    {
        await _authRepository.DeleteByUserIdAsync(request.Id);

        await _userRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
