using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record UpdateUserHandler : IHandler<UpdateUserRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler
    (
        IUnitOfWork unitOfWork,
        IUserRepository userRepository
    )
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

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
