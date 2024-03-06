using static System.Net.HttpStatusCode;

namespace Architecture.Application;

public sealed record AuthHandler : IHandler<AuthRequest, AuthResponse>
{
    private readonly IAuthRepository _authRepository;
    private readonly IHashService _hashService;
    private readonly IJwtService _jwtService;
    private readonly IStringLocalizer _stringLocalizer;

    public AuthHandler
    (
        IAuthRepository authRepository,
        IHashService hashService,
        IJwtService jwtService,
        IStringLocalizer stringLocalizer
    )
    {
        _authRepository = authRepository;
        _hashService = hashService;
        _jwtService = jwtService;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Result<AuthResponse>> HandleAsync(AuthRequest request)
    {
        var unauthorizedResult = new Result<AuthResponse>(Unauthorized, _stringLocalizer[nameof(Unauthorized)]);

        var auth = await _authRepository.GetByLoginAsync(request.Login);

        if (auth is null) return unauthorizedResult;

        if (!_hashService.Validate(auth.Password, request.Password, auth.Salt.ToString())) return unauthorizedResult;

        var token = _jwtService.Encode(auth.Id.ToString(), auth.Roles.ToArray());

        var response = new AuthResponse(token);

        return new Result<AuthResponse>(OK, response);
    }
}
