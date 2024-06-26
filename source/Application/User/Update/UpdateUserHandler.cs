using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed class UpdateUserHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository
    ) : IHandler<UpdateUserRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result> HandleAsync(UpdateUserRequest request)
    {
        var user = await _userRepository.GetAsync(request.Id);

        if (user is null) return new Result(NotFound);

        user.UpdateName(request.Name);

        user.UpdateEmail(request.Email);

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
