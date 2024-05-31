using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record AddUserHandler : IHandler<AddUserRequest, long>
{
    private readonly IAuthRepository _authRepository;
    private readonly IHashService _hashService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public AddUserHandler
    (
        IAuthRepository authRepository,
        IHashService hashService,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository
    )
    {
        _authRepository = authRepository;
        _hashService = hashService;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result<long>> HandleAsync(AddUserRequest request)
    {
        var user = new User(request.Name, request.Email);

        var auth = new Auth(request.Login, request.Password, user);

        var password = _hashService.Create(auth.Password, auth.Salt.ToString());

        auth.UpdatePassword(password);

        await _userRepository.AddAsync(user);

        await _authRepository.AddAsync(auth);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, user.Id);
    }
}
